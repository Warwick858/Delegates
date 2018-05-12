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
using System.Collections.Generic;

namespace Delegates
{
    public class TestDelegate
    {
        //Declare & Initialize Constants:
        const string EMPTY = "EMPTY";

        //Delegates:
        public delegate string Values(int i, double d, char c, string s);
        public delegate string Empty();

        //Declare Data Members:
        private List<Func<int, double, char, string, string>> _DList;

        public TestDelegate()
        {
            //Initialize DList to built-in delegate that takes 4 params and returns a string
            _DList = new List<Func<int, double, char, string, string>>();
        } // end default constructor

        public void RunTests()
        {
            //Declare & init vars:
            int idata = 1;
            double ddata = 5.1;
            char cdata = 'A';
            string sdata = "Method";

            //Fill the DList
            PopulateDList();

            //Foreach method in DList
            foreach (Func<int, double, char, string, string> myDel in _DList)
            {
                //Call method and print returned value to console
                Console.WriteLine(myDel(idata, ddata++, cdata++, sdata + idata++));
            }
        } // end method RunTests()

        public void PopulateDList()
        {
            //EXAMPLE: Lamda to method *******************************************
            Func<int, double, char, string, string> format = (i, d, c, s) => Format(i, d, c, s);
            //Add it to the list
            _DList.Add(format);

            //EXAMPLE: CHAINING DELEGATES - INVOCATION LIST  ********************************************
            //Create instance of Values delegate using Format()
            Values delValues1 = new Values(Format);
            //Create another instance of Values
            Values delValuesChain = new Values(Format);
            //Add it to delValues1 invocation list
            delValues1 += delValuesChain;

            //EXAMPLE: BUILT-IN FUNC DELEGATE, LAMBDA TO MY DELEGATE ********************************************
            //Wrap delegate in Func
            Func<int, double, char, string, string> funcDelVal = (i, d, c, s) => delValues1(i, d, c, s);
            //Add it to the list
            _DList.Add(funcDelVal);

            //EXAMPLE: BUILT-IN FUNC DELEGATE USING ANONYMOUS METHOD WITH MULTI-LINED LAMBDA ********************************************
            Func<int, double, char, string, string> anonymousMethod = (i, d, c, s) =>
            {
                //Format the given data and return it
                return "\t" + s + ": " + i + "\n\t\tDouble: " + d + "\n\t\tChar: " + c + "\n";
            };
            //Add it to the list
            _DList.Add(anonymousMethod);

            //EXAMPLE: DELEGATE WITH EMPTY PARAMETERS ********************************************
            Empty empty = () =>
            {
                string test = EMPTY;
                return test;
            };

            //EXAMPLE: CUSTOM DELEGATES ********************************************
            //Create 2 custom delegate options
            Func<int, double, char, string, string> delCustom1 = (i, d, c, s) => (Format(i, d, c, s)).ToString();
            Func<int, double, char, string, string> delCustom2 = (i, d, c, s) => (Format(i, d, c, s)).ToString();
            //Add them to the list
            _DList.Add(delCustom1);
            _DList.Add(delCustom2);

            //Call the test function, passing delegate option
            CustomTest(delCustom1);
            CustomTest(delCustom2);

            //EXAMPLE: BUILT-IN ACTION DELEGATE ********************************************
            //Add FuncToAction method to list to exhibit Action<> delegate use
            _DList.Add(FuncToAction);

            //EXAMPLE: BUILT-IN PREDICATE DELEGATE ********************************************
            //Add FuncToAction method to list to exhibit Predicate<> delegate use
            _DList.Add(FuncToAction);
        } // end method PopulateDList

        /// <summary>
        /// To format the given int, double, char, and string
        /// </summary>
        public string Format(int idata, double ddata, char cdata, string sdata)
        {
            //Format the given data and return it
            return "\n\t" + sdata + ": " + idata + "\n\t\tDouble: " + ddata + "\n\t\tChar: " + cdata + "\n";
        } // end method Format()

        /// <summary>
        /// To simulate a function using delegate options
        /// </summary>
        public void CustomTest(Func<int, double, char, string, string> del)
        {
            //do nothing
        } // end method CustomTest()

        /// <summary>
        /// Wrapper function for Action<>
        /// </summary>
        public string FuncToAction(int idata, double ddata, char cdata, string sdata)
        {
            //EXAMPLE: BUILT-IN ACTION DELEGATE USING ANONYMOUS METHOD WITH MULTI-LINED LAMBDA *************
            Action<int, double, char, string> delAction = ((i, d, c, s) =>
            {
                //do nothing
            });

            //Format the given data and return it
            return "\n\t" + sdata + ": " + idata + "\n\t\tDouble: " + ddata + "\n\t\tChar: " + cdata + "\n";
        } // end method FuncToAction()

        /// <summary>
        /// Wrapper function for Predicate<>
        /// </summary>
        public string FuncToPredicate(int idata, double ddata, char cdata, string sdata)
        {
            //EXAMPLE: BUILT-IN PREDICATE DELEGATE USING ANONYMOUS METHOD WITH LAMBDA *************
            Predicate<string> delPredicate = (s =>
            {
                return true;
            });

            //Format the given data and return it
            return "\n\t" + sdata + ": " + idata + "\n\t\tDouble: " + ddata + "\n\t\tChar: " + cdata + "\n";
        } // end method FuncToAction()
    } // end class TestDelegate
} // end namespace
