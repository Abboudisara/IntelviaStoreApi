import React ,{useState} from 'react'

function Categorie(){
 const [nom,setNom] = useState("");
 const [description,setDescription] = useState("");
 const [imagename,setImageName] = useState("");



 async function addCategorie()
 {
  console.warn(nom,description,imagename)
//   const formData = new FormData();
//   formData.append('nom', nom);
//   formData.append('description', description);
//   formData.append('imagename', imagename);
let item={nom, description, imagename}

 let result= await fetch("https://localhost:44347/api/Categorie",{
     method:'POST',
     body:JSON.stringify(item),  
     headers:{
        "Content-Type":'application/json',
        "Accept":'application/json'
     }
 });
 
console.warn("result",result)
alert("Category has been Saved")
 }

    return(
        <div>
            <h1 className='col-sm-6 offset-sm-5'>Add CATEGORIES</h1>
            <div className='col-sm-6 offset-sm-3'>
            <input type="text" className="form-control"  onChange={(e)=>setNom(e.target.value)} placeholder="Name"/>
            <br/>
            <input type="text" className="form-control"   onChange={(e)=>setDescription(e.target.value)}  placeholder="Descrtiption"/>
            <br/>
            <input type="file" className="form-control" onChange={(e)=>setImageName(e.target.files[0].name)} placeholder="File"/>
            <br/>
            <button onClick={addCategorie} className="btn btn-warning col-sm-6 offset-sm-3 " >Add Categories</button>
            </div>
        </div>
    )
}
export default Categorie