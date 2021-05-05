import React ,{useState} from 'react'


function Product(){
 const [nom,setNom] = useState("");
 const [prix,setprix] = useState(0);
 const [description,setdescription ] = useState("");
 const [qtsock,setQStock ] = useState(0);
 const [imagename,setImageName ] = useState("");

 



 async function addCategorie()
 {
  console.warn(nom,description,imagename)
//   const formData = new FormData();
//   formData.append('nom', nom);
//   formData.append('description', description);
//   formData.append('imagename', imagename);
let item={nom, prix, description, qtsock,imagename}

 let result= await fetch("https://localhost:44347/api/Product",{
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
            <input type="text" className="form-control"  onChange={(e)=>setprix(e.target.value)} placeholder="Price"/>
            <br/>
            <input type="text" className="form-control"   onChange={(e)=>setdescription(e.target.value)}  placeholder="Descrtiption"/>
            <br/>
            <input type="text" className="form-control"   onChange={(e)=>setQStock(e.target.value)}  placeholder="Quantiter de Stock"/>
            <br/>
            <input type="file" className="form-control" onChange={(e)=>setImageName(e.target.files[0].name)} placeholder="File"/>
            <br/>
            <button onClick={addCategorie} className="btn btn-warning col-sm-6 offset-sm-3 " >Add Products</button>
            </div>
        </div>
    )
}
export default Product;