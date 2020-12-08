using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_Registration_WebApp
{
    public partial class Register : System.Web.UI.Page
    {
        // Create a list of parts.
        public static List<string> personalCode = new List<string>();
        public static char caseSwitchPersonalCode;
        public static string birthPersonalCode;
        public static string birthSerialDayPersonalCode;
        public static string stringTrim;
        public static double sControlNumerFirst;
        public static double sControlNumerSecond;
        public static double sControlNumerFinal;

        public Register()
        {
            this.Load += new EventHandler(this.Page_Load);

            personalCode.Add("33309240064");
            personalCode.Add("49310149380");
            personalCode.Add("30308278513"); /* For Testing */
            personalCode.Add("38806189205");
            personalCode.Add("43103209329");
            personalCode.Add("51509289717"); /* For born day similar check 971 day*/
            personalCode.Add("51509289717"); /* For born day similar check 971 day*/
            personalCode.Add("51509289727"); /* For born day differently check 972 day*/
        }

        /* only numbers */
/*        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }*/

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {

            if (nameField.Text.Equals("") || surnameField.Text.Equals("") || personalCodeField.Text.Equals("") ||
                genderSelection.SelectedIndex == 0 || addressField.Text.Equals("") || telephoneField.Text.Equals("") ||
                programSelection.SelectedIndex == 0)
            {
                errorLabel.Text = "Fill/Select all Labels/Selections";
                return;
            }

            if (agreeCheck.Checked == false)
            {
                errorLabel.Text = "Accept our policy";
                return;
            }

            if (Regex.IsMatch(telephoneField.Text, @"(((86|\+3706) \d{3} \d{4})" +
                                                   @"|((86|\+3706)\d{3}\d{4})|" +
                                                   @"((86|\+3706) \d{3}\d{4})|" +
                                                    @"((86|\+3706)\d{3} \d{4}))"))
            {
                phoneLabel.Text = "Lithuanian phone number is valid";
            }
            else
            {
                phoneLabel.Text = "Lithuanian phone number not valid";
                return;
            }
            

            if (personalCodeField.Text.Count().Equals(11))
            {
                if (Regex.IsMatch(personalCodeField.Text, @"\d+$")) /*Regular_Expressions only numbers*/
                {
                    foreach(string a in personalCode)
                    {
                        if (personalCodeField.Text.Contains(a))  /* to check as personCodeField, do not contains to existing ...*/
                        {
                            studentExists.Text = "This student already exists in our data";
                            return;
                        }
                        else
                        {
                            studentExists.Text = "This student not exists in our data";
                        }
                    }
                    
                    // Check Creation Validation by Lithuania Rules
                    for (int ctr = 0; ctr <= personalCodeField.Text.Length - 1; ctr++)
                    {
                        /*the first shows the century of birth and the sex of the person (1 - a man born in
                         * the 19th century, 2 - a woman born in the 19th century, 3 - a man born in the 20th
                         * century, 4 - a woman born in the 20th century, 5 - a man born in the XXI century,
                         * 6 - A woman born in the 21st century);*/
                        if(ctr == 0) /* First Element */
                        {
                            caseSwitchPersonalCode = personalCodeField.Text[0];
                            switch (caseSwitchPersonalCode)
                            {
                                case '1':
                                    Console.WriteLine("XIX a.gimęs vyras");
                                    errorLabel.Text = "XIX a.gimęs vyras 1";
                                    break;
                                case '2':
                                    Console.WriteLine("XIX a.gimusi moteris");
                                    errorLabel.Text = "XIX a.gimusi moteris 2 ";
                                    break;
                                case '3':
                                    Console.WriteLine(" XX a.gimęs vyras");
                                    errorLabel.Text = "XX a.gimęs vyras 3 ";
                                    break;
                                case '4':
                                    Console.WriteLine("XX a.gimusi moteris");
                                    errorLabel.Text = "XX a.gimusi moteris 4";
                                    break;
                                case '5':
                                    Console.WriteLine("XXI a.gimęs vyras");
                                    errorLabel.Text = "XXI a.gimęs vyras 5";
                                    break;
                                case '6':
                                    Console.WriteLine("XXI a.gimusi moteris");
                                    errorLabel.Text = "XXI a.gimusi moteris 6";
                                    break;
                                default:
                                    birthdayLabel.Text = "Wrong Personal Code (CenturyBirthday)!";
                                    return;
                            }
                           }/* if (ctr == 0)  First Element */

                        /*the next six are the last two digits of the person's year of birth, month (two digits), day (two digits);
                         YYMMDD*/
                        if (/*ctr > 1 || */ctr == 6) /* First Element */
                        {

                            /*
                                                        string dateString = Convert.ToString(personalBirthday[1]
                                                                                   + personalBirthday[2]
                                                                                   + personalBirthday[3]
                                                                                   + personalBirthday[4]
                                                                                   + personalBirthday[5]
                                                                                   + personalBirthday[6]);*/
                            stringTrim = personalCodeField.Text;
                            birthPersonalCode = stringTrim.Substring(1,6);
                            /*regular expression */
                            /* Validates leap years.*/
                            var regEx = @"^((\d{2}( " +
                                        "(0[13578]|1[02])"+
                                        @"(0[1-9]|[12]\d|3[01])|" +
                                        "(0[13456789]|1[012])"+
                                        @"(0[1-9]|[12]\d|30)" +
                                        @"|02(0[1-9]|1\d|2[0-8])))" +
                                        "|([02468][048]|[13579][26])0229)$";
                            /* | Or alternative */
                            /* \d - [0-9]
                             * d{2} - Matches two digits - YYMMDD
                             * First Group
                             * (0[13578]|1[02]) -> month 1.3.5.7.8...12..
                             * (0[1-9]|[12]\d|3[01])| -> day 
                             */

                            if (Regex.IsMatch(birthPersonalCode, regEx)) /*Regular_Expressions */
                            {
                                /* Next step ... ctr == 10*/
                            }
                            else
                            {
                                errorLabel.Text = "Wrong Personal Code (BirthdayDate)!";
                                return;
                            }
                            /*errorLabel.Text = "Neveikia!";*/
                        }/* if (ctr == 0)  First Element */

                        /*the next three digits are the serial number of persons born on that day;*/
                        if (/*ctr > 6 || */ctr == 9)
                        {
                            /*Serial number of persons born can't repeat, soo... */
                            stringTrim = personalCodeField.Text;
                            string getTrim;
                            birthSerialDayPersonalCode = stringTrim.Substring(7, 3);

                            foreach(string pers in personalCode)
                            {
                                stringTrim = pers;
                                getTrim = stringTrim.Substring(7, 3);

                                if(birthSerialDayPersonalCode.Contains(getTrim))
                                {
                                    errorLabel.Text = "Wrong Personal Code (birthSerialDay)!";
                                    return;
                                }
                            }
                            /* Next step ... ctr = 11 */
                        } /*if (ctr > 6 || ctr < 11)*/

                        /*the last is a check digit derived from other digits.*/
                        if (ctr == 10)
                        {
                            try
                            {
                                char[] chars = personalCodeField.Text.ToCharArray();

                                int[] personalCodeInt = Array.ConvertAll(chars, c => (int)Char.GetNumericValue(c));


                                sControlNumerFirst = (personalCodeInt[0] * 1 + personalCodeInt[1] * 2 + personalCodeInt[2] * 3 + personalCodeInt[3]
                                    * 4 + personalCodeInt[4] * 5 + personalCodeInt[5] * 6 + personalCodeInt[6] * 7 + personalCodeInt[7] * 8
                                    + personalCodeInt[8] * 9 + personalCodeInt[9] * 1) % 11;


                                if (sControlNumerFirst == 10)
                                {
                                    sControlNumerSecond = (personalCodeInt[0] * 3 + personalCodeInt[1] * 4 + personalCodeInt[2] * 5 + personalCodeInt[3] *
                                        6 + personalCodeInt[4] * 7 + personalCodeInt[5] * 8 + personalCodeInt[6] * 9 + personalCodeInt[7] *
                                        1 + personalCodeInt[8] * 2 + personalCodeInt[9] * 3) % 11;
                                    if (sControlNumerSecond == 10)
                                    {
                                        sControlNumerFinal = 0;
                                    /*    errorLabel.Text = "Oh yess == 0 " + +sControlNumerFinal;
                                        return;*/
                                    }
                                    else
                                    {
                                        sControlNumerFinal = sControlNumerSecond;
                                     /*   errorLabel.Text = "Oh yess >>  " + sControlNumerFinal;
                                        return;*/
                                    }
                                }
                                else
                                {
                                    sControlNumerFinal = sControlNumerFirst;
                                   /* errorLabel.Text = " ohh yes ==  " + sControlNumerFinal;
                                    return;*/
                                }
                            }
                            catch(Exception ex)
                            {
                                errorLabel.Text = ex.ToString();
                            }
/* Jei asmens kodas užrašomas ABCDEFGHIJK, tai:
S = A*1 + B*2 + C*3 + D*4 + E*5 + F*6 + G*7 + H*8 + I*9 + J*1
Suma S dalinama iš 11, ir jei liekana nelygi 10, ji yra asmens kodo kontrolinis 
skaičius K. Jei liekana lygi 10, tuomet skaičiuojama nauja suma su tokiais svertiniais koeficientais:
S = A*3 + B*4 + C*5 + D*6 + E*7 + F*8 + G*9 + H*1 + I*2 + J*3
Ši suma S vėl dalinama iš 11, ir jei liekana nelygi 10, ji yra asmens kodo kontrolinis 
 skaičius K. Jei vėl liekana yra 10, kontrolinis skaičius K yra 0. */
                        }
                    } // Check Creation Validation by Lithuania Rules

                       //Create personal Code
                      personalCode.Add(personalCodeField.Text);
                     personalCodeLabel.Text = "All Done!";
                    /* errorLabel.Text = "Fignia.... :(";*/
                            return;
                } /* End of if (Regex.IsMatch(personalCodeField.Text, @"\d+$")) */
                else
                {
                    errorLabel.Text = "Ne is skaiciu .... :( ";
                    return;
                }
            } /* End of  if (personalCodeField.Text.Count().Equals(11)) */
            else
            {
                errorLabel.Text = "Personal identification code in Lithuania Consists of a 11-digit";
                return;
            }

          /*  foreach (long a in personalCode)
            {

            }*/

            Response.Redirect("Default.aspx");
        }
    }
}