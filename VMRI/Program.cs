using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMRI
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {           
            Program o = new Program();
            o.VerifyRecommendations();            
        }

        private void VerifyRecommendations()
        {
            List<VMSizeLocation> newRI       = GetNewRIRecommendations();
            List<VMSizeLocation> currentRI   = GetCurrentRIPurchases();
            List<VMSizeLocation> overlapRI = new List<VMSizeLocation>();
            List<VMSizeLocation> nonOverlapRI = new List<VMSizeLocation>();
            
            foreach (VMSizeLocation newPair in newRI)
            {
                foreach(VMSizeLocation currentPair in currentRI)
                {                    
                    if ((newPair.Size == currentPair.Size)
                        && (newPair.Location == currentPair.Location))
                    {
                        overlapRI.Add(newPair);
                        break;
                    }         
                }
                if (!overlapRI.Contains(newPair)) 
                {
                    nonOverlapRI.Add(newPair);
                }
            }

            if(overlapRI.Count > 0)
            {
                Console.WriteLine($"Recommendation (Size, Location) which overlap with Purchases:{overlapRI.Count}");
                foreach(VMSizeLocation overlapPair in overlapRI)
                {
                    Console.WriteLine(overlapPair.Size + "," + overlapPair.Location);
                }

            }
            Console.WriteLine();
            if (nonOverlapRI.Count > 0)
            {
                Console.WriteLine($"Recommendation (Size, Location) which don't overlap with Purchases:{nonOverlapRI.Count}");
                foreach (VMSizeLocation nonOverlapPair in nonOverlapRI)
                {
                    Console.WriteLine(nonOverlapPair.Size + "," + nonOverlapPair.Location);
                }

            }
        }

        private List<VMSizeLocation> GetCurrentRIPurchases()
        {
            string[,] arrCurrentRI =
            {
                { "Standard_DS13_v2","westus" },
                { "Standard_DS13_v2","eastus" },
                { "Standard_DS12_v2","eastus" },
                { "Standard_D2s_v3","westus" },
                { "Standard_DS14_v2","eastus" },
                { "Standard_D2s_v3","eastus2" },
                { "Standard_D16ls_v5","eastus" },
                { "Standard_E8as_v5","eastus" },
                { "Standard_E4as_v5","eastus" },
                { "Standard_E8bs_v5","eastus" },
                { "Standard_E8-4as_v5","eastus" },
                { "Standard_E2as_v5","eastus" },
                { "Standard_E4as_v5","eastus" },
                { "Standard_E4as_v5","eastus" },
                { "Standard_D2s_v3","eastus2" },
                { "Standard_D4ads_v5","eastus2" },
                { "Standard_B4as_v2","eastus" },
                { "Standard_B2as_v2","eastus" },
                { "Standard_D2s_v3","eastus" }
            };            

            return GetRIPairList(arrCurrentRI);
        }

        private List<VMSizeLocation> GetNewRIRecommendations()
        {
            string[,] arrNewRI =
            {
                { "Standard_A1_v2","eastus" },
                { "Standard_A2","eastus" },
                { "Standard_B2as_v2","eastus" },
                { "Standard_B2s","eastus" },
                { "Standard_B2s_v2","eastus" },
                { "Standard_B4as_v2","eastus" },
                { "Standard_B8as_v2","eastus" },
                { "Standard_D1","eastus" },
                { "Standard_D2s_v3","eastus" },
                { "Standard_D2s_v3","eastus" },
                { "Standard_D4ds_v5","eastus2" },
                { "Standard_D8ds_v5","eastus2" },
                { "Standard_DS12_v2","eastus" },
                { "Standard_DS3_v2","eastus2" },
                { "Standard_E16s_v3","eastus2" },
                { "Standard_E2s_v3","eastus2" },
                { "Standard_E4as_v5","eastus" },
                { "Standard_E4bs_v5","eastus" }
            };

            return GetRIPairList(arrNewRI);
        }

        private List<VMSizeLocation> GetRIPairList(string[,] arrRI)
        {
            List<VMSizeLocation> listRI = new List<VMSizeLocation>();
            for (int newRIRecoCount = 0; newRIRecoCount < arrRI.GetLength(0); newRIRecoCount++)
            {
                listRI.Add(new VMSizeLocation()
                {
                    Size = arrRI[newRIRecoCount, 0],
                    Location = arrRI[newRIRecoCount, 1]
                });
            }
            return listRI;
        }

        class VMSizeLocation
        {
            public required string Size { get; set; }
            public required string Location { get; set; }
        }
    }
}
