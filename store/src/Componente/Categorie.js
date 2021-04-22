import React,{useState,useEffect} from 'react'

const defaultourceImage='/img/123.png'

const initialFieldValues={
    id :0,
    Nom:'',
    ImageNam :'',
    SourceImage:defaultourceImage,
    Image:null

}

const showPreview=e=>{
    if(e.target.files && e.target.files[0]){
        let Image=e.target.files[0];
        const reader=new FileReader();
        reader.onload=x=>{
            setValues({
            ...values,
        Image,
        SourceImage:x.target.result
    })
            
        }
        reader.readAsDataURL(Image)
    }
}

export default function Categorie() {
    const [values,setValues]=useState(initialFieldValues)
    const handleIputChange=e=> {
        const{name,value}=e.target;
        setValues({
            ...values,
            [name]:value

        })
    }
    return (
        <>
        <div className="container text-center">
          <p className="Lead">An Category</p>
        </div>

        <form autoComplete="off" noValidate>
             <div className="card">
                 <img src={values.SourceImage} className="card-img-top"/>
             <div className="card-body">
                 <div className="form-group">
                     <input type="file" accept="image/*" className="form-control-file" 
                     onChange={showPreview}/>
                 </div>

               <div className="form-group">
                   <input className="form-control" placeholder="Category Name" 
                   name="Nom" value={values.Nom} onChange={handleIputChange} />
               </div>

               
             </div>
             </div>
        </form>
        </>
    )
}
