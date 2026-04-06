<?php

class ProgramWindow
{
    public $y;
    public $x;
    public $height;
    public $width;

    function __construct(int $y = 0, int $x = 0, int $height = 600, int $width = 800)
    {
        $this->y = $y;
        $this->x = $x;
        $this->height = $height;
        $this->width = $width;
    }

    function resize(Size $size) : void
    {
        $this->height = $size->height;
        $this->width = $size->width;
    }

    function move(Position $position) : void
    {
        $this->x = $position->x;
        $this->y = $position->y;
    }
}