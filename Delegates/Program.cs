// ******************************************************************************************************************
//  Delegates - simple spike for different types of delegates in C#
//  Copyright(C) 2018  James LoForti
//  Contact Info: jamesloforti@gmail.com
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see<https://www.gnu.org/licenses/>.
//									     ____.           .____             _____  _______   
//									    |    |           |    |    ____   /  |  | \   _  \  
//									    |    |   ______  |    |   /  _ \ /   |  |_/  /_\  \ 
//									/\__|    |  /_____/  |    |__(  <_> )    ^   /\  \_/   \
//									\________|           |_______ \____/\____   |  \_____  /
//									                             \/          |__|        \/ 
//
// ******************************************************************************************************************
//
using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare Constants:
            const string ABOUT = "Name: James LoForti \n*************************************\n ";
            const string RESULTS_HEADER = "************Test Results************* \n";

            //Print headers
            Console.WriteLine(ABOUT);
            Console.WriteLine(RESULTS_HEADER);

            //Create instance of TestDelegate
            TestDelegate td = new TestDelegate();

            //Run tests
            td.RunTests();

            //Halt for user input, then exit
            Console.Write("Press any key to continue... ");
            Console.ReadKey(true);
        } // end Main()
    } // end class Program
} // end namespace
