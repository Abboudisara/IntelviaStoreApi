import React ,{useState} from 'react'
//import {useHistory} from 'react-router-dom'
function Register(){
    const [username,setUserName]=useState("")
    const [email,setEmail]=useState("")
    const [password,setPassword]=useState("")
   // const history=useHistory();
    
   async function SignUp()
    {
        
        let item={username,email,password}
        console.warn(item)
      let result=await  fetch("https://localhost:44347/api/ManagementUser/Register",{
            method:'POST',
            body:JSON.stringify(item),
            headers:{
                "Content-Type":'application/json',
                "Accept":'application/json'
            }
        })
        result= await result.json()
        console.warn("result",result)
        //localStorage.setItem("user-info",JSON.stringify(result))
       // history.push("Login")
    }
    return(
        <div className="col-sm-6 offset-sm-3">
          <h1 className="col-sm-6 offset-sm-3">Register Pages</h1>
          
          <input type="text" value={username} onChange={(e)=>setUserName(e.target.value)} className="form-control " placeholder="user Name"/>
          <br/>
          <input type="text" value={email} onChange={(e)=>setEmail(e.target.value)} className="form-control " placeholder="Email"/>
          <br/>
          <input type="passeword" value={password} onChange={(e)=>setPassword(e.target.value)} className="form-control " placeholder="passeword"/>
          <br/>
          <button onClick={SignUp} className="btn btn-primary col-sm-6 offset-sm-3">Sign up</button>
        </div>
    )
}

export default Register