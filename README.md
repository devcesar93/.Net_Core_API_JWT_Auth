Api básica utilizando os conceitos de autenticação com JWT.

A Api acessa uma tabela chamada Acesso, e outra chamada Contatos, ambas criadas utilizando o Migrations. 

Foi criada uma View para informar o login e senha, caso o usuário esteja cadastrado na tabela acesso, o sistema internamente cria as Claims e retorna o token de autenticação.

Referências utilizadas:
Microsoft.AspNetCore.All v2.0;
Microsoft.IdentityModel.Tokens v5.5.0
System.IdentityModel.Tokens.Jwt v5.5
System.Security.Claims v4.3


 Classe de geração do Token:
  private string GenerateToken(string email)
        {
            var claims = new Claim[]
            {
                //define as claims para criação do token
                new Claim(ClaimTypes.Name, email),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            //gera o token baseado nas claims
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretpassword"));
            SigningCredentials signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtHeader jwtHeader = new JwtHeader(signingCredential);
            JwtPayload jwtPayload = new JwtPayload(claims);
            JwtSecurityToken token = new JwtSecurityToken(jwtHeader, jwtPayload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

