using FluentValidation;

namespace Haskap.TcknValueObject;

public class TcknValidator : AbstractValidator<string>
{
    public TcknValidator()
    {
        RuleFor(x => x)
            .Must(HaveValidAlgorithm);
    }

    private bool HaveValidAlgorithm(string trIdValue)
    {
        long aTrId, bTrId, trIdAsNumber;
        long c1, c2, c3, c4, c5, c6, c7, c8, c9, q1, q2;

        trIdAsNumber = long.Parse(trIdValue);

        aTrId = trIdAsNumber / 100;
        bTrId = trIdAsNumber / 100;

        c1 = aTrId % 10; aTrId = aTrId / 10;
        c2 = aTrId % 10; aTrId = aTrId / 10;
        c3 = aTrId % 10; aTrId = aTrId / 10;
        c4 = aTrId % 10; aTrId = aTrId / 10;
        c5 = aTrId % 10; aTrId = aTrId / 10;
        c6 = aTrId % 10; aTrId = aTrId / 10;
        c7 = aTrId % 10; aTrId = aTrId / 10;
        c8 = aTrId % 10; aTrId = aTrId / 10;
        c9 = aTrId % 10; aTrId = aTrId / 10;
        q1 = ((10 - ((((c1 + c3 + c5 + c7 + c9) * 3) + (c2 + c4 + c6 + c8)) % 10)) % 10);
        q2 = ((10 - (((((c2 + c4 + c6 + c8) + q1) * 3) + (c1 + c3 + c5 + c7 + c9)) % 10)) % 10);

        var returnValue = ((bTrId * 100) + (q1 * 10) + q2 == trIdAsNumber);

        return returnValue;
    }
}
