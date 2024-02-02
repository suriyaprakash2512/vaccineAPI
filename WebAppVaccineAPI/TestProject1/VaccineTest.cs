using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
        public class VaccineTest
        {
            public bool vaccineTest(string VaccineName)
            {
                return VaccineName == "Covaxin";
            }
        }
        [TestFixture]

        public class VacTest
        {
            [Test]
            public void ValidMatchingVacTest()
            {
                var vaccineTest = new VaccineTest();
                bool result = vaccineTest.vaccineTest("Covaxin");
                Assert.IsTrue(result);
            }
            [Test]
            public void InvalidMatchingVacTest()
            {
                var vaccineTest = new VaccineTest();
                bool result = vaccineTest.vaccineTest("Covidshield");
                Assert.IsFalse(result);
            }
           
        }

    }

