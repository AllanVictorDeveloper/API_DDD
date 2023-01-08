using System.IdentityModel.Tokens.Jwt;

namespace WebAPIs.Token
{
    public class TokenJWT
    {
        private JwtSecurityToken _token;

        internal TokenJWT(JwtSecurityToken token)
        {
            this._token = token;
        }


        public DateTime ValidoAte => _token.ValidTo;

        public string valor => new JwtSecurityTokenHandler().WriteToken(this._token);

    }
}
