long myNumber = 32331430;

int myNumberLength = (int)Math.Log10(myNumber) + 3;

string[] digitText = new string[myNumberLength + myNumberLength / 3 + 3];

string[] ones = { "", "egy", "kettő", "három", "négy", "öt", "hat", "hét", "nyolc", "kilenc" };
string[] tens = { "", "tizen", "húszon", "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven" };
string[] wholeTens = { "", "tíz", "húsz", "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven" };
string[] hundreds = { "", "száz", "kétszáz", "háromszáz", "négyszáz", "ötszáz", "hatszáz", "hétszáz", "nyolcszáz", "kilencszáz" };
string[] groups = { "", "ezer", "millió", "milliárd", "billió", "billiárd", "trillió", "trilliárd", "kvadrillió", "kvadrilliárd" };

int digitPosition = 0;
int groupPosition = 0;

int threeDigits;
int one, ten, hundred;

while (myNumber > 0)
{
    threeDigits = (int)(myNumber % 1000);

    if (threeDigits == 0)
    {
        for (int i = 0; i < 3; i++)
        {
            digitText[digitPosition] = "";
            digitPosition++;
        }
        groupPosition++;
    }
    else
    {
        addDigitText(groups, groupPosition);

        one = threeDigits % 10;
        ten = threeDigits % 100 / 10;
        hundred = threeDigits / 100;

        addDigitText(ones, one);

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

for (int i = digitText.Length - 1; i > -1; i--)
{
    Console.Write(digitText[i]);
    // Output example: "harminckettőmillióháromszázharmincezernégyszázharminc"
}

void addDigitText(string[] digitArray, int position)
{
    digitText[digitPosition] = digitArray[position];
    digitPosition++;
    if (digitArray == groups)
    {
        groupPosition++;
    }
}