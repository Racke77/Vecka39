using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bankomat_2
{
    public class MyJsonWriter
    {
        //method for taking the full list of BankAccount-objects, and converting it to an object-type with different properties
        //in case something shouldn't be included (passwords, etc)
        public static string WriteToFile(List<BankAccount> bankAccounts, string fileName)
        {
            List<BankAccountJsonDto> listToSave = new List<BankAccountJsonDto>(); //new list
            foreach (BankAccount bankAccount in bankAccounts) //fill list with other list
            {
                BankAccountJsonDto bankAccountJsonDto = BankAccountJsonDto.FromBankAccount(bankAccount);
                listToSave.Add(bankAccountJsonDto);
            }
            string loadString = JsonSerializer.Serialize(listToSave); //serializing the new list
            System.IO.File.WriteAllText($@"{fileName}.tmp.json", loadString); //write to a temp file
            File.Copy($@"{fileName}.tmp.json", $@"{fileName}.json", true); //copy temp file to actual file
            return loadString;
        }
        public static List<BankAccount> LoadFromFile(string fileName)
        {
            string loadString = System.IO.File.ReadAllText($@"{fileName}.json"); //load from file

            //read the string -> convert to jsonDto-List
            List<BankAccountJsonDto> bankAccountJsonDtos = JsonSerializer.Deserialize<List<BankAccountJsonDto>>(loadString) ?? new List<BankAccountJsonDto>();

            //take json-Dto-List and make it into the real BankAccount-list
            List<BankAccount> loadBankAccounts = new List<BankAccount>();
            foreach (var item in bankAccountJsonDtos)
            {
                BankAccount bankAccount = item.ToBankAccount();
                loadBankAccounts.Add(bankAccount);
            }
            return loadBankAccounts;
        }
    }
}
