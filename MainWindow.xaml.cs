using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szyfr_Vigenere_a
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string key = ShiftTextBox.Text;
            string plaintext = PlainTextBox.Text;
            string encryptedText = Encrypt(plaintext,key);
            EncryptedTextBlock.Text = encryptedText;
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string key = ShiftTextBox2.Text;
            string ciphertext = EncryptedTextBox.Text;
            string decryptedText = Decrypt(ciphertext, key);
            DecryptedTextBlock.Text = decryptedText;
        }



        //static string Encrypt(string plaintext, string key)
        //{
        //    string encryptedText = "";
        //    plaintext = plaintext.ToUpper();
        //    key = key.ToUpper();

        //    int keyIndex = 0;
        //    foreach (char letter in plaintext)
        //    {
        //        if (char.IsLetter(letter))
        //        {
        //            int plaintextNum = letter - 'A';
        //            int keyNum = key[keyIndex] - 'A';

        //            int encryptedNum = (plaintextNum + keyNum) % 26;
        //            char encryptedChar = (char)('A' + encryptedNum);

        //            encryptedText += encryptedChar;

        //            keyIndex = (keyIndex + 1) % key.Length;
        //        }
        //        else
        //        {
        //            encryptedText += letter;
        //        }
        //    }

        //    return encryptedText;
        //}

        //// Metoda deszyfrująca tekst zaszyfrowany szyfrem Vigenère
        //static string Decrypt(string encryptedText, string key)
        //{
        //    string decryptedText = "";
        //    encryptedText = encryptedText.ToUpper();
        //    key = key.ToUpper();

        //    int keyIndex = 0;
        //    foreach (char letter in encryptedText)
        //    {
        //        if (char.IsLetter(letter))
        //        {
        //            int encryptedNum = letter - 'A';
        //            int keyNum = key[keyIndex] - 'A';

        //            int decryptedNum = (encryptedNum - keyNum + 26) % 26;
        //            char decryptedChar = (char)('A' + decryptedNum);

        //            decryptedText += decryptedChar;

        //            keyIndex = (keyIndex + 1) % key.Length;
        //        }
        //        else
        //        {
        //            decryptedText += letter;
        //        }
        //    }

        //    return decryptedText;
        //}

        static string Encrypt(string plaintext, string key)
        {
            string encryptedText = "";
            plaintext = plaintext.ToUpper();
            key = key.ToUpper();

            int keyIndex = 0;
            foreach (char letter in plaintext)
            {
                if (char.IsLetter(letter))
                {
                    int plaintextNum = GetAlphabetIndex(letter);
                    int keyNum = GetAlphabetIndex(key[keyIndex]);

                    int encryptedNum = (plaintextNum + keyNum) % 32; // 32 - liczba liter w polskim alfabecie
                    char encryptedChar = GetAlphabetChar(encryptedNum);

                    encryptedText += encryptedChar;

                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    encryptedText += letter;
                }
            }

            return encryptedText;
        }

        static string Decrypt(string encryptedText, string key)
        {
            string decryptedText = "";
            encryptedText = encryptedText.ToUpper();
            key = key.ToUpper();

            int keyIndex = 0;
            foreach (char letter in encryptedText)
            {
                if (char.IsLetter(letter))
                {
                    int encryptedNum = GetAlphabetIndex(letter);
                    int keyNum = GetAlphabetIndex(key[keyIndex]);

                    int decryptedNum = (encryptedNum - keyNum + 32) % 32; // 32 - liczba liter w polskim alfabecie
                    char decryptedChar = GetAlphabetChar(decryptedNum);

                    decryptedText += decryptedChar;

                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    decryptedText += letter;
                }
            }

            return decryptedText;
        }

        // Funkcja zwracająca indeks litery w polskim alfabecie
        static int GetAlphabetIndex(char letter)
        {
            string polishAlphabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUWYZŹŻ";
            return polishAlphabet.IndexOf(letter);
        }

        // Funkcja zwracająca literę w polskim alfabecie na podstawie indeksu
        static char GetAlphabetChar(int index)
        {
            string polishAlphabet = "AĄBCĆDEĘFGHIJKLŁMNŃOÓPQRSŚTUWYZŹŻ";
            return polishAlphabet[index];
        }
    }
}
