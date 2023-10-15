﻿using System.Diagnostics.Metrics;

long myNumber = 323123411230430;
int myNumberLength = (int)Math.Log10(myNumber) + 3;

// meg tudom magyarázni, ez hogy jön ki :D
string[] digitText = new string[myNumberLength + myNumberLength / 3 + 3];

string[] ones = { "", "egy", "kettő", "három", "négy", "öt", "hat", "hét", "nyolc", "kilenc" };
string[] tens = { "", "tizen", "húszon", "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven" };
string[] wholeTens = { "", "tíz", "húsz", "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven" };
string[] hundreds = { "", "száz", "kétszáz", "háromszáz", "négyszáz", "ötszáz", "hatszáz", "hétszáz", "nyolcszáz", "kilencszáz" };
string[] thousands = { "", "ezer", "millió", "milliárd", "billió", "billiárd", "trillió", "trilliárd", "kvadrillió", "kvadrilliárd" };

int digitPosition = 0;
int thousandPosition = 0;

int treeDigits;
int one;
int ten;
int hundred;

while (myNumber > 0)
{
    treeDigits = (int)(myNumber % 1000);

    if (treeDigits == 0)
    {
        for (int i = 0; i < 3; i++)
        {
            digitText[digitPosition] = "";
            digitPosition++;
        }
        thousandPosition++;
    }
    else
    {
        digitText[digitPosition] = thousands[thousandPosition];
        digitPosition++;
        thousandPosition++;
        one = treeDigits % 10;
        ten = treeDigits % 100 / 10;
        hundred = treeDigits / 100;

        digitText[digitPosition] = ones[one];
        digitPosition++;

        if (one == 0)
        {
            digitText[digitPosition] = wholeTens[ten];
            digitPosition++;
        }
        else
        {
            digitText[digitPosition] = tens[ten];
            digitPosition++;
        }

        digitText[digitPosition] = hundreds[hundred];
        digitPosition++;
    }

    myNumber /= 1000;
}

for (int i = digitText.Length - 1; i > -1; i--)
{
    Console.Write(digitText[i]);
}