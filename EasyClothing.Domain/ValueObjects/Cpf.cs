using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EasyClothing.Domain.ValueObjects
{
    public sealed class Cpf : IEquatable<Cpf>
    {
        public string Number { get; }

        public Cpf(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("CPF cannot be empty");

            number = Normalize(number);

            if (!IsValid(number))
                throw new ArgumentException("Invalid CPF");

            Number = number;
        }

        private static string Normalize(string cpf)
        {
            return Regex.Replace(cpf, @"\D", "");
        }

        public string GetFormatted()
        {
            return $"{Number.Substring(0, 3)}.{Number.Substring(3, 3)}.{Number.Substring(6, 3)}-{Number.Substring(9, 2)}";
        }

        public override string ToString()
            => GetFormatted();

        public override bool Equals(object obj)
            => Equals(obj as Cpf);

        public bool Equals(Cpf other)
            => other != null && Number == other.Number;

        public override int GetHashCode()
            => Number.GetHashCode();

        public static implicit operator string(Cpf cpf)
            => cpf.Number;

        public static implicit operator Cpf(string number)
            => new Cpf(number);

        private static bool IsValid(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            // evita CPFs inválidos tipo 11111111111
            if (cpf.Distinct().Count() == 1)
                return false;

            var digits = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            // primeiro dígito
            var sum = 0;
            for (int i = 0; i < 9; i++)
                sum += digits[i] * (10 - i);

            var firstDigit = sum % 11;
            firstDigit = firstDigit < 2 ? 0 : 11 - firstDigit;

            if (digits[9] != firstDigit)
                return false;

            // segundo dígito
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += digits[i] * (11 - i);

            var secondDigit = sum % 11;
            secondDigit = secondDigit < 2 ? 0 : 11 - secondDigit;

            return digits[10] == secondDigit;
        }
    }
}
