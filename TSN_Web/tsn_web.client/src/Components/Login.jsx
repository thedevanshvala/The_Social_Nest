function Login() {
  return (
    <div style={{
      display: 'flex',
      justifyContent: 'center',
      alignItems: 'center',
      height: '100vh',
      width: '100vw' // Ensure full width
    }}>
      <div style={{
        padding: '10px',
        border: '1px solid #ccc',
        borderRadius: '10px',
        boxShadow: '0px 0px 10px rgba(0, 0, 0, 0.1)',
        minWidth: '300px' // Prevents it from becoming too small
      }}>
        <div style={{ textAlign:'center', padding:'center' } }>
        <label id="tabelLabel" style={{ fontSize: '24px', fontWeight: 'bold', textAlign:'center'}}>Login_TSN</label>
        </div>                                                                                                                                                                                                                                        
        <div style={{ marginBottom: '10px' }}>
          <label>Email:
            <input type="email" style={{ marginLeft: '38px', width: '70%', height:'25px' }} />
          </label>
        </div>
        <div style={{ marginBottom: '10px' }}>
          <label>Password:
            <input type="password" style={{ marginLeft: '10px', width: '70%', height:'25px' }} />
          </label>              
        </div>
        <div style={{ textAlign: 'center', marginTop:'20px' }}>
          <button className="Login"> Login </button>
          <button className="Register" style={{ marginLeft: '5px' }}> Register</button>
          <div style={{ marginTop: '5px' }}>
            <button className="Forgot_Password">Forgot Password</button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Login;
