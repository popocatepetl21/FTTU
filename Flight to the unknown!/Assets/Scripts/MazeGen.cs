using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Flags]
public enum WallState
{
    //0000 no walls
    //1111 Left, right, up, down
    LEFT = 1, //0001
    RIGHT = 2, //0010
    UP = 3, //0100
    DOWN = 4, //1000
}
public static class MazeGen 
{
     public static WallState[,] Generate(int width, int height){
    WallState[,] maze = new WallState[width, height];
    //Initially all the walls EXIST
    WallState initial = WallState.RIGHT | WallState.LEFT | WallState.UP |WallState.DOWN;
    for (int i=0; i< width; ++i){
        for (int j=0; j<height; ++j){
            maze[i,j] = initial; //1111
        }
    }
    maze[0, Random.Range(0, height)] &= ~WallState.LEFT; // Remove left wall of leftmost cell
    maze[width-1, Random.Range(0, height)] &= ~WallState.RIGHT; // Remove right wall of rightmost cell
    return ApplyRecursiveBacktracker(maze, width, height);
}
}