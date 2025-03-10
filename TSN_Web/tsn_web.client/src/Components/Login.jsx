import React, { useState } from 'react';
import axios from 'axios';

function Login() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async () => {
        try {
            const response = await axios.post('https://localhost:7234/Login/login', {
                email,
                password
            });
            alert(`Login Successful: ${response.data.message}`);
        } catch (error) {
            alert(`Login Failed: ${error.response?.data || 'An error occurred'}`);
        }
    };

    const handleForgotPassword = async () => {
        try {
            const response = await axios.post('https://localhost:7234/Login/forgot-password', {
                email
            });
            alert(`Password Reset Email Sent: ${response.data.message}`);
        } catch (error) {
            alert(`Error: ${error.response?.data || 'An error occurred'}`);
        }
    };

    return (
        <div style={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            height: '100vh',
            width: '100vw'
        }}>
            <div style={{
                padding: '10px',
                border: '1px solid #ccc',
                borderRadius: '10px',
                boxShadow: '0px 0px 10px rgba(0, 0, 0, 0.1)',
                minWidth: '300px'
            }}>
                <div style={{ textAlign: 'center', padding: 'center' }}>
                    <label id="tabelLabel" style={{ fontSize: '24px', fontWeight: 'bold', textAlign: 'center' }}>
                        Login_TSN
                    </label>
                </div>

                <div style={{ marginBottom: '10px' }}>
                    <label>Email:
                        <input
                            type="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            style={{ marginLeft: '38px', width: '70%', height: '25px' }}
                        />
                    </label>
                </div>

                <div style={{ marginBottom: '10px' }}>
                    <label>Password:
                        <input
                            type="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            style={{ marginLeft: '10px', width: '70%', height: '25px' }}
                        />
                    </label>
                </div>

                <div style={{ textAlign: 'center', marginTop: '20px' }}>
                    <button className="Login" onClick={handleLogin}>Login</button>
                    <button className="Register" style={{ marginLeft: '5px' }}>Register</button>
                    <div style={{ marginTop: '5px' }}>
                        <button className="Forgot_Password" onClick={handleForgotPassword}>Forgot Password</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Login;
