// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


double Y = 0; //user input

double compute(double Y)
{
    //reject Y=0
    double squareRoot = 0; 
    while(Y != squareRoot)
    {
        squareRoot = 0.50 * (squareRoot + Y / squareRoot);
    }
    return Y;
}

compute(Y);