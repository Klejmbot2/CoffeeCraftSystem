using System;

namespace CoffeeCraftApp
{
    public static class MetodyRozszerzajace
    {
        public static bool CzyZawieraSformulowanieGrzecznosciowe(this string tekstMowiony)
        {
            string tekst = tekstMowiony.ToLower();
            return tekst.Contains("proszę") || tekst.Contains("dzień dobry") || tekst.Contains("poproszę");
        }
    }
}