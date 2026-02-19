using System;
using System.Text.RegularExpressions;

namespace EasyClothing.Domain.ValueObjects
{
    public sealed class CellPhone : IEquatable<CellPhone>
    {
        public string Number { get; }

        public CellPhone(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Número de Celular não pode ser vazio");

            number = Normalize(number);

            if (!IsValid(number))
                throw new ArgumentException("Número de celular inválido");

            Number = number;
        }

        private static string Normalize(string number)
        {
            // remove tudo que não for número
            number = Regex.Replace(number, @"\D", "");

            // remove código país se tiver
            if (number.StartsWith("55") && number.Length == 13)
                number = number.Substring(2);

            return number;
        }

        private static bool IsValid(string number)
        {
            // formato brasileiro: DDD + 9 dígitos
            var regex = new Regex(
                @"^\d{11}$",
                RegexOptions.Compiled);

            return regex.IsMatch(number);
        }

        public string GetFormatted()
        {
            return $"({Number.Substring(0, 2)}) {Number.Substring(2, 5)}-{Number.Substring(7, 4)}";
        }

        public override string ToString()
            => GetFormatted();

        public override bool Equals(object obj)
            => Equals((CellPhone)obj);

        public bool Equals(CellPhone other)
            => other != null && Number == other.Number;

        public override int GetHashCode()
            => Number.GetHashCode();

        public static implicit operator string(CellPhone phone)
            => phone.Number;

        public static implicit operator CellPhone(string number)
            => new CellPhone(number);
    }
}
