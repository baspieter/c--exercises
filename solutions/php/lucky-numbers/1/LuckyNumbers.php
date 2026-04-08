<?php

class LuckyNumbers
{
    public function sumUp(array $digitsOfNumber1, array $digitsOfNumber2): int
    {
        return (int) implode($digitsOfNumber1) + (int) implode($digitsOfNumber2);

    }

    public function isPalindrome(int $number): bool
    {
        return strrev((string) $number) == (string) $number;
    }

    public function validate(string $input): string
    {
        if ((int) $input > 0)
            {
                return '';
            }
        else if ($input == '')
            {
                return 'Required field';
            }
        else
            {
                return 'Must be a whole number larger than 0';
            }
    }
}
