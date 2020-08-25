using CustomerRegistration.Models;
using CustomerRegistration.Validations;

namespace CustomerRegistration.Services
{
    class RegisterService
    {
        private ClientValidation _clientValidation;

        public RegisterService()
        {
            _clientValidation = new ClientValidation();
        }

        public string RegisterClient(ClientModel client)
        {
            return _clientValidation.ValidateClient(client);

            ///implementar cadastro no banco de dados
        }

    }
}
