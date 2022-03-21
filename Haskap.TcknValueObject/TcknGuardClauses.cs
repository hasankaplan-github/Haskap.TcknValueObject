using Haskap.TcknValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardalis.GuardClauses;

public static class TcknGuardClauses
{
    public static string InvalidTrIdAlgorithm(this IGuardClause guardClause, string input, string parameterName, string? message = null)
    {
        var tcknValidator = new TcknValidator();
        var valiationResult = tcknValidator.Validate(input);

        if (valiationResult.IsValid == false)
            throw new ArgumentException(message, parameterName);

        return input;
    }
}
