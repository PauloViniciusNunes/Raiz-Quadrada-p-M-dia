using System;


public class SQR{
    public static decimal SquareRoot(decimal parameter){
        for(decimal i = parameter; i >= 0; i -= 0.0001m){
            if(i*i == parameter){
                return i;
            }
            else{
                continue;
            }    
        }
        return -1;
    }
       
    public static decimal GuestRange(decimal sameparameter, string guestype){
        if(guestype == "max"){
            for(decimal x = sameparameter; true; x += 1){
                if(SquareRoot(x) != -1){
                    return x;
                    break;
                }
            }
        }
        else if(guestype == "min"){
            for(decimal x = sameparameter; true; x -= 1){
                if(SquareRoot(x) != -1){
                    return x;
                    break;
                }
            }
        }
        else{
            return 0;
        }
    }


    private static void Main(string[] args){
        Console.Write("Number: ");
        decimal theNumber = decimal.Parse(Console.ReadLine());
        if(SquareRoot(theNumber) == -1){
            decimal ProxMaxSquareRoot = SquareRoot(GuestRange(theNumber, "max"));
            decimal ProxMinSquareRoot = SquareRoot(GuestRange(theNumber, "min"));
            decimal IntermediumSquare = (ProxMaxSquareRoot + ProxMinSquareRoot)/2;
            decimal AuxiliarOne;
            for(int i = 0; i < 125; i++){
                if(theNumber > IntermediumSquare*IntermediumSquare){
                    AuxiliarOne = (ProxMinSquareRoot + IntermediumSquare)/2;
                    if(theNumber > AuxiliarOne*AuxiliarOne){
                        ProxMinSquareRoot = AuxiliarOne;
                    }
                }
                else if(theNumber < IntermediumSquare*IntermediumSquare){
                    AuxiliarOne = (ProxMaxSquareRoot + IntermediumSquare)/2;
                    if(theNumber < AuxiliarOne*AuxiliarOne){
                        ProxMaxSquareRoot = AuxiliarOne;
                    }
                }
                else{
                    IntermediumSquare = (ProxMaxSquareRoot + ProxMinSquareRoot)/2;
                    break;
                }
                IntermediumSquare = (ProxMaxSquareRoot + ProxMinSquareRoot)/2;
            }
            Console.WriteLine("The square root of "+theNumber+" is "+IntermediumSquare);
        }
        else{
            Console.WriteLine("The square root of "+theNumber+" is "+SquareRoot(theNumber));
        }
    }
}

