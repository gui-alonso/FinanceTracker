// Simulando autenticação
export async function fakeLogin(email, password) {
  if (email === 'admin@example.com' && password === '123456') {
    return { token: 'fake-jwt-token', user: { name: 'Admin' } };
  }
  throw new Error('Credenciais inválidas');
}

// Simulando registro
export async function fakeRegister(name, email, password) {
  if (email && password && name) {
    return { message: 'Usuário cadastrado com sucesso' };
  }
  throw new Error('Erro ao cadastrar');
}
