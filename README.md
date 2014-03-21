RookPoly
http://www.youtube.com/watch?v=5HjWGSzAq4Q&feature=plcp
========

A Rook Polynomial mathematically describes the number of ways to place 
0 ... (the lesser of m and n) rook chess pieces on a m x n chess board.
The idea is that it is easier to calculate the total number of rooks that
can be placed instead of counting each number individually.

Ex. 1 + 81x + 9x^2 says there is 1 way to place 0 rooks, 9 ways to place 2
and 81 ways to place 2 rooks. From this knowledge, you can infer the board 
is a 9 x 9 square. 

My solution to this problem was a good lesson in recursion, as that is how 
we solved these problems in one of my math classes. 

For example, 
We start with 1 way to place 0 rooks on any board.
Then we acquire more cases, which will now on be described in polynomial notation as above. 
```
+---+
|   | = 1 + x (1 way to place 0, and 1 way to place 1)\n
+---+

+---+---+
|   |   | = 1 + 2x
+---+---+

+---+---+
|   |   |
+---+---+ = 1 + 3x + x^2
|   |
+---+

+---+---+
|   |   |
+---+---+ = 1 + 4x + 2x^2
|   |   |
+---+---+

    +---+
    |   |       +---+
+---+---+ = 2 * |   | = 2*(1+x)
|   |           +---+
+---+
```
... and so on. 

Using these we can start with any board and form a polynomial representing it. 
In order to do so, we must select a single tile, then delete it from the board, multiply the new board's 
polynomial by x, and add that result to a new board formed by deleting the row and column of the selected
cell. 

For example
```
+---+---+---+
|   |   |   |
+---+---+---+
|   |   |
+---+---+

+---+---+---+       +---+---+---+
| X | X | X |       |   |   | X |
+---+---+---+ + x * +---+---+---+
|   |   |           |   |   |
+---+---+           +---+---+

                +---+---+
+---+---+       |   |   |
|   |   | + x * +---+---+
+---+---+       |   |   |
                +---+---+
```
Using our base cases, we now get 1 + 2x + x*(1 + 4x + 2x^2) = 1 + 3x + 4x^2 + 2x^3. 

The process of determining the polynomial within the program breaks the board down into a single tile, 
causing the calculation to take slower than it would if I had determined a way for it to recogize base 
case shapes. In an effort to increase the speed, I threaded the calculation process. 

Further work on this project would include a way to view the possible ways to place these combinations of rooks. 
