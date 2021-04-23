import React from 'react'
import Categorie from './Categorie'
import axios from "axios";

export default function CategoryList() {
const CategoryAPI =(url='https://localhost:44347/api/Categorie')=>{
    return{
        fetchAll:()=>axios.get(url),
        create:newRecord=>axios.post(url,newRecord),
        update:(id,updateRecord)=>axios.put(url+id,updateRecord),
        delete:id=>axios.delete(url+id)
    }
}


    const addOrEdit =(formData,onSuccess)=>{
       CategoryAPI().create(formData)
       .then(res=>{
           onSuccess();
       })
       .catch(err=>console.log(err))
    }
return (
<div className="row">
<div className="col-md-12">
<div className="jumbotron jumbotron-fluid py-4">
<div className="container text-center">
<h1 className="display-4">Categories</h1>
    
  </div>
</div>
</div>

            <div className="col-md-4">
                        <Categorie
                        addOrEdit={addOrEdit}
                        />
            </div>

            <div className="col-md-8">
                <div>List of Categories</div>
           </div>
        </div>
    )
}
