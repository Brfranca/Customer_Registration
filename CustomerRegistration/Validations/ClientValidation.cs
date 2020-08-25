using CustomerRegistration.Models;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomerRegistration.Validations
{
    class ClientValidation
    {
        public string ValidateClient(ClientModel client)
        {
            string result = (ValidateRequiredFields(client));
            if (!string.IsNullOrWhiteSpace(result))
                return result;

            StringBuilder errors = new StringBuilder();
            ValidateName(client.Name, errors);
            result = ValidateCpf(client.Cpf);
            if (!string.IsNullOrWhiteSpace(result))
                errors.AppendLine(result);
            ValidateAge(client.Birth, errors);
            ValidateGender(client.Gender, errors);
            ValidateBloodType(client.BloodType, errors);
            result = ValidateNationality(client.Nationality);
            if (!string.IsNullOrWhiteSpace(result))
                errors.AppendLine(result);
            ValidateCellPhone(client.Phone, errors);
            ValidateSchooling(client.Schooling, errors);
            ValidateEmail(client.Email, errors);
            ValidateCEP(client.CEP, errors);
            ValidateStreet(client.Street, errors);
            ValidateNumber(client.Number, errors);
            ValidateDistrict(client.District, errors);
            ValidateCity(client.City, errors);
            ValidateState(client.State, errors);

            return errors.ToString();
        }

        private void ValidateName(string name, StringBuilder errors)
        {
            if (name.Length < 3 || name.Length > 50)
                errors.AppendLine("O nome deve conter de 3 à 50 caracteres.");
            if (!ValidateLetter(name))
                errors.AppendLine("O nome deve conter apenas letras.");
        }

        private string ValidateCpf(string cpf)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return "O CPF deve conter 11 dígitos.";
            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            if (!cpf.EndsWith(digit))
                return "CPF inválido";
            return null;
        }

        private void ValidateAge(DateTime birth, StringBuilder errors)
        {
            DateTime birth_18 = birth.AddYears(18);
            DateTime today = DateTime.Now;
            if (birth_18.Date > today.Date)
                errors.AppendLine("O usuário deve ter, no mínimo, 18 anos.");
        }

        private void ValidateGender(string gender, StringBuilder errors)
        {
            string[] validgenders = { "Indeterminado", "Feminino", "Masculino" };
            if (!validgenders.Contains(gender))
                errors.AppendLine("Selecione uma opção de gênero.");
        }

        private void ValidateBloodType(string bloodType, StringBuilder errors)
        {
            string[] validBloodTypes = { "A +", "A -", "B +", "B -", "AB +", "AB -", "O +", "O -" };

            if (!validBloodTypes.Contains(bloodType))
                errors.AppendLine("Tipo sanguíneo inválido.");
        }

        private string ValidateNationality(string nationality)
        {
            if (!ValidateLetter(nationality))
                return "A nacionalidade deve conter apenas letras.";
            if (nationality.Length < 3 || nationality.Length > 40)
                return "A nacionalidade deve conter de 3 à 50 caracteres.";
            return null;
        }

        private void ValidateSchooling(string schooling, StringBuilder errors)
        {
            string[] validSchooling = {"Fundamental Incompleto", "Fundamental Completo", "Médio Incompleto",
                "Médio Completo", "Superior Incompleto", "Superior Completo", "Pós-Graduação", "Mestrado",
                "Doutorado", "PhD"};

            if (!validSchooling.Contains(schooling))
                errors.AppendLine("Escolaridade inválida.");
        }

        private void ValidateCellPhone(string phone, StringBuilder errors)
        {
            if (!Regex.IsMatch(phone, @"^\(\d{2}\) \d{5}-\d{4}$"))
                errors.AppendLine("Telefone inválido.");
        }

        private void ValidateEmail(string email, StringBuilder errors)
        {
            Regex emailRegex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");

            if (!emailRegex.IsMatch(email))
                errors.AppendLine("E-mail inválido.");
        }

        private void ValidateCEP(string cep, StringBuilder errors)
        {
            if (!Regex.IsMatch(cep, @"^\d{5}-\d{3}$"))
                errors.AppendLine("CEP inválido.");
        }

        private void ValidateStreet(string street, StringBuilder errors)
        {
            if (street.Length < 3 || street.Length > 70)
                errors.AppendLine("A rua deve conter de 3 à 70 caracteres.");
            if (!Regex.IsMatch(street, @"^[0-9\p{L}\p{M}' \.\-]+$"))
                errors.AppendLine("A rua deve conter apenas letras e números.");
        }

        private void ValidateNumber(string number, StringBuilder errors)
        {
            if (!Regex.IsMatch(number, "^[0-9]+$"))
                errors.AppendLine("O Nº deve conter apenas números.");
        }

        private void ValidateDistrict(string district, StringBuilder errors)
        {
            if (district.Length < 3 || district.Length > 40)
                errors.AppendLine("O bairro deve conter de 3 à 40 caracteres.");
            if (!Regex.IsMatch(district, @"^[0-9\p{L}\p{M}' \.\-]+$"))
                errors.AppendLine("O bairro deve conter apenas letras e números.");
        }

        private void ValidateCity(string city, StringBuilder errors)
        {
            if (city.Length < 3 || city.Length > 40)
                errors.AppendLine("A cidade deve conter de 3 à 40 caracteres.");
            if (!ValidateLetter(city))
                errors.AppendLine("A cidade deve conter apenas letras.");
        }

        private void ValidateState(string state, StringBuilder errors)
        {
            string[] validStates = {"AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG",
            "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"};

            if (state.Length != 2 || !Regex.IsMatch(state, "^[a-zA-Z]+$"))
                errors.AppendLine("A sigla UF deve conter 2 letras.");
            else if (!validStates.Contains(state))
                errors.AppendLine("UF inválida.");
        }

        private bool ValidateLetter(string words)
        {
            return Regex.IsMatch(words, @"^[\p{L}\p{M}' \.\-]+$");
        }

        private string ValidateRequiredFields(ClientModel client)
        {
            string result = "Preencha os campos obrigatórios!";
            if (string.IsNullOrWhiteSpace(client.Name))
                return result;
            if (!(client.Cpf).Any(char.IsNumber))
                return result;
            if (client.Gender == "Selecione")
                return result;
            if (client.BloodType == "Selecione")
                return result;
            if (string.IsNullOrWhiteSpace(client.Nationality))
                return result;
            if (client.Schooling == "Selecione")
                return result;
            if (!(client.Phone).Any(char.IsNumber))
                return result;
            if (string.IsNullOrWhiteSpace(client.Email))
                return result;
            if (!(client.CEP).Any(char.IsNumber))
                return result;
            if (client.City == "Selecione")
                return result;
            if (client.State == "Selecione")
                return result;
            if (string.IsNullOrWhiteSpace(client.Street))
                return result;

            return null;
        }
    }
}
