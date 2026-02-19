using System;
using System.Text.RegularExpressions;

namespace EasyClothing.Domain.ValueObjects
{
    public sealed class Cep : IEquatable<Cep>
    {
        public string Code { get; }

        public Cep(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("CEP cannot be empty");

            code = Normalize(code);

            if (!IsValid(code))
                throw new ArgumentException("Invalid CEP format");

            Code = code;
        }

        private static string Normalize(string cep)
        {
            cep = cep.Replace("-", "").Trim();

            return $"{cep.Substring(0, 5)}-{cep.Substring(5, 3)}";
        }

        private static bool IsValid(string cep)
        {
            var regex = new Regex(
                @"^\d{5}-\d{3}$",
                RegexOptions.Compiled);

            return regex.IsMatch(cep);
        }

        public override string ToString()
            => Code;

        public override bool Equals(object obj)
            => Equals(obj as Cep);

        public bool Equals(Cep other)
            => other != null && Code == other.Code;

        public override int GetHashCode()
            => Code.GetHashCode();

        public static implicit operator string(Cep cep)
            => cep.Code;

        public static implicit operator Cep(string code)
            => new Cep(code);
    }
}
