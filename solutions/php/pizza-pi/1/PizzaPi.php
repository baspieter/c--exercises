<?php

class PizzaPi
{
    public function calculateDoughRequirement($pizzas, $people)
    {
        return $pizzas * (($people * 20) + 200);
    }

    public function calculateSauceRequirement($pizzas, $canSize)
    {
        return $pizzas * 125 / $canSize;
    }

    public function calculateCheeseCubeCoverage($cube, $thickness, $diameter)
    {
        return floor(pow($cube, 3) / ($thickness * pi() * $diameter));
    }

    public function calculateLeftOverSlices($pizzas, $friends)
    {
        return ($pizzas * 8) % $friends;
    }
}
