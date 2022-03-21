using Ardalis.GuardClauses;
using Haskap.DddBase.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haskap.TcknValueObject;

public class Tckn : ValueObject
{
    public string? Value { get; private set; }

    public Tckn(string? value, bool allowNullOrEmpty)
    {
        value = value?.Trim();

        if (allowNullOrEmpty == false)
        {
            Guard.Against.NullOrEmpty(value, nameof(value), "__InvalidTrId__");
            Guard.Against.InvalidTrIdAlgorithm(value, nameof(value), "__InvalidTrId__");

            Value = value;
        }
        else if (string.IsNullOrEmpty(value) == false)
        {
            Value = Guard.Against.InvalidTrIdAlgorithm(value, nameof(value));
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
