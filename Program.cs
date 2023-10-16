long myNumber = 2430000;

int myNumberLength = (int)Math.Log10(myNumber) + 3;

string[] digitText = new string[myNumberLength + myNumberLength / 3 + 3];

string[] ones = { "", "egy", "kettő", "három", "négy", "öt", "hat", "hét", "nyolc", "kilenc" };
string[] tens = { "", "tizen", "húszon", "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven" };
string[] wholeTens = { "", "tíz", "húsz", "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven" };
string[] hundreds = { "", "száz", "kétszáz", "háromszáz", "négyszáz", "ötszáz", "hatszáz", "hétszáz", "nyolcszáz", "kilencszáz" };

string[] groups = { "", "ezer", "millió-", "milliárd-", "billió-", "billiárd-", "trillió-", "trilliárd-", "kvadrillió-", "kvadrilliárd-" };
groups[1] += myNumber > 2000 ? "-" : "";

int digitPosition = 0;
int groupPosition = 0;

int threeDigits;
int one, ten, hundred;

while (myNumber > 0)
{
    threeDigits = (int)(myNumber % 1000);

    if (threeDigits == 0)
    {
        addDigitText(ones, 0);
        addDigitText(tens, 0);
        addDigitText(hundreds, 0);
        groupPosition++;
    }
    else
    {
        one = threeDigits % 10;
        ten = threeDigits % 100 / 10;
        hundred = threeDigits / 100;

        addDigitText(groups, groupPosition);

        if (digitPosition == 5 && myNumber == 1)
        {
            addDigitText(ones, 0);
        }
        else
        {
            addDigitText(ones, one);
        }

        if (one == 0)
        {
            addDigitText(wholeTens, ten);
        }
        else
        {
            addDigitText(tens, ten);
        }
        addDigitText(hundreds, hundred);
    }

    myNumber /= 1000;
}

string outputText = "";
for (int i = digitText.Length - 1; i > -1; i--)
{
    outputText += digitText[i];
}

char lastCharacter = outputText[outputText.Length - 1];
if (lastCharacter == '-')
{
    outputText = outputText.Remove(outputText.Length-1);
}

Console.WriteLine(outputText);

void addDigitText(string[] digitArray, int position)
{
    digitText[digitPosition] = digitArray[position];
    digitPosition++;
    if (digitArray == groups)
    {
        groupPosition++;
    }
}