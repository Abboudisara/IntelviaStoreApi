import React ,{useState,useEffect} from 'react'
//import {useHistory} from 'react-router-dom'

function Login()
{
  const[username,setUserName]=useState("");
  const[password,setPassword]=useState("");
 
   useEffect(() => {
      if(localStorage.getItem('user-info')){
         
      }
   }, [])

 async function login(){
    console.warn(username,password)
    let item={username,password}
   let result=await fetch("https://localhost:44347/api/ManagementUser/Login",{
    method:'POST',
    headers:{
        "Content-Type":'application/json',
        "Accept":'application/json'
    },
    body:JSON.stringify(item),
   })
   result= await result.json()
   localStorage.setItem('user-info',JSON.stringify(result))
   history.push("/Dashboard")
} 

  return(
    <div className="col-sm-6 offset-sm-3">
       
        <h1 className="col-sm-6 offset-sm-4">Login Page</h1>
        <div className="col-sm-6 offset-sm-3">
        <input type="text" placeholder="email"onChange={(e)=>setUserName(e.target.value)}  className="form-control"/>
        <br/>
        <input type="passeword" placeholder="passeword" onChange={(e)=>setPassword(e.target.value)} className="form-control"/>
        <br/>
        <button onClick={login} className="btn btn-primary col-sm-6 offset-sm-3">Login</button>
        </div>
    </div>
)

}


export default Login




