import React,{useState,useEffect} from 'react'
const defaultourceImage='/img/123.png'

const initialFieldValues={
    //id :"",
    nom:'',
    imageName :'',
    sourceImage:defaultourceImage,
    image:null

}



export default function Categorie(props) {
const {addOrEdit}=props

    const [values,setValues]=useState(initialFieldValues)
    const [errors,setErrors]=useState({})

    const handleIputChange=e=> {
        const{name,value}=e.target;
        setValues({
            ...values,
            [name]:value

        })
    }


    const showPreview=e=>{
        if(e.target.files && e.target.files[0]){
            let image=e.target.files[0];
            const reader=new FileReader();
            reader.onload = x =>{
                setValues({
            ...values,
            image,
            sourceImage:x.target.result
        })
                
            }
            reader.readAsDataURL(image)
        }
        else{
    
            setValues({
                ...values,
                image:null,
                sourceImage:defaultourceImage,
            })
        }
    }
const validate=()=>{
    let temp={}
    
    temp.nom=values.nom==""?false:true;
    temp.sourceImage=values.sourceImage==defaultourceImage?false:true;
    setErrors(temp)
    return Object.values(temp).every(x=>x==true)
}

const resetForm=()=>{
    setValues(initialFieldValues)
    document.getElementById('image-uploader').value=null;
    setErrors({})
}

const handleFormSubmit = e => {
        e.preventDefault()
        if(validate()){
        const formData= new FormData()
        //formData.append(' id',values.id)
        formData.append('nom',values.nom)
        formData.append('imageName',values.imageName)
        formData.append(' image',values.image)
        addOrEdit(formData,resetForm)
        }
    }

    const applyErrorClass = field =>((field in errors && errors[field]==false)?' invalid-field':'' )



    return (
        <>
        <div className="container text-center">
          <p className="Lead">An Category</p>
        </div>

        <form autoComplete="off" noValidate onSubmit={handleFormSubmit}>
             <div className="card">
                 <img src={values.sourceImage} className="card-img-top"/>
             <div className="card-body">
                 <div className="form-group">
                     <input type="file" accept="image/*" className={"form-control-file"+applyErrorClass('sourceImage')}
                     onChange={showPreview} id="image-uploader"/>
                 </div>

               <div className="form-group">
                   <input className={"form-control-file"+applyErrorClass('nom')} placeholder="Category Name" 
                   name="nom" value={values.nom} onChange={handleIputChange} />
               </div>

           <div className="form-group text-center">
           <button type="submit" className="btn btn-light">Submit</button>
           </div>
               
             </div>
             </div>
        </form>
        </>
    )
}
