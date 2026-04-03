<?php

class HighSchoolSweetheart
{
    public function firstLetter(string $name): string
    {
        return substr(trim($name, ' '), 0, 1);
    }

    public function initial(string $name): string
    {
        $initial = strtoupper($this->firstLetter($name));
        return "$initial.";
    }

    public function initials(string $name): string
    {
        $names = explode(" ", $name);
        $first_initial = $this->initial($names[0]);
        $second_initial = $this->initial($names[1]);
        return "$first_initial $second_initial";
    }

    public function pair(string $sweetheart_a, string $sweetheart_b): string
    {
        $sweetheart_a_initials = $this->initials($sweetheart_a);
        $sweetheart_b_initials = $this->initials($sweetheart_b);
        // return "$sweetheart_a_initials + $sweetheart_b_initials";

return <<<END
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     $sweetheart_a_initials  +  $sweetheart_b_initials     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
END;
    }
}
