using System;
using System.Text.RegularExpressions;

namespace EasyClothing.Domain.ValueObjects
{
    public sealed class Email : IEquatable<Email>
    {
        public string Address { get; }

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Email cannot be empty");

            if (!IsValid(address))
                throw new ArgumentException("Invalid email format");

            Address = address.ToLower().Trim();
        }

        private static bool IsValid(string email)
        {
            var regex = new Regex(
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.Compiled);

            return regex.IsMatch(email);
        }

        public override string ToString()
            => Address;

        public override bool Equals(object obj)
            => Equals(obj as Email);

        public bool Equals(Email other)
            => other != null && Address == other.Address;

        public override int GetHashCode()
            => Address.GetHashCode();

        public static implicit operator string(Email email)
            => email.Address;

        public static implicit operator Email(string address)
            => new Email(address);
    }
}
