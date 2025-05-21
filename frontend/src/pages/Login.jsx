import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { fakeLogin } from '../services/api';
import { saveToken } from '../utils/auth';
import '../App.css';

export default function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await fakeLogin(email, password);
      saveToken(response.token);
      navigate('/dashboard');
    } catch (err) {
      setError(err.message);
    }
  };

  return (
    <div className="container">
      <h2>Login</h2>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <form className='form' onSubmit={handleLogin}>
        
        <input type="email" placeholder="E-mail" value={email} onChange={(e) => setEmail(e.target.value)} required />
        <input type="password" placeholder="Senha" value={password} onChange={(e) => setPassword(e.target.value)} required />
        <button type="submit">Entrar</button>
      </form>
      <p>Não tem conta? <a href="/register">Cadastre-se</a></p>
    </div>
  );
}
