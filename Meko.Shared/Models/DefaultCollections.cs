namespace Meko.Shared.Models;

public static class DefaultCollections
{
    private static readonly string[] _defaultProfilePhotos = new string[5]
    {
        "default/blue.jpg",
        "default/red.jpg",
        "default/yellow.jpg",
        "default/green.jpg",
        "default/violet.jpg"
    };

    private static readonly string[] _defaultCoverPhotos = new string[37]
    {
        "YFCypCEC9NtTdJ6pGUUQ2FQDPRYtXnV7pRqt2f6uRhjd9z7SjcdkYcBWj0ObwZ3YVhpcoKSPCv7zNq4fRhMWI0wke2Dnl7WjvyRhAxyl4CXSLmrwD5yACe1rrnh6RMb3.jpg",
        "sLUacGDcHznQsO7qLVH6TBHHh6SGfVcsX2k50ghwL8na8abNuG7uO650yKqe93052MhsgaJjzdn1x2XjSj7d8YodySX2I3BpU0H6wkKrEncpmAoG0rRAcGfqc07PkTRN.jpg",
        "ueoqcbmeCj82Mco3e5ndAC64jG3CAJQMiMsZ1LvasxMRmgke4aolAI6i3PtM7Od8eEvNFhHcnY04KxI2cVVZxMUmZt90XXAbLt8T66NgnL4V0KP0RqLtPyzcHBeAEK64.jpg",
        "9MM2zo6kIpo56bTITsFh2C0KBq08c7yOvy978l7VVDgYD7RPXuRmoPSZdWjM5XrGxhQMt6yoDvjWLgubUJzwjGREwH9QIew4Ju0pSyhfZHKpKHODADTB7YQ0H4usyJA2.jpg",
        "DeFx6EnbuRSO2nTAOYEEpATAFUAGkxSs1C4uxK0BiJkmGKqoh3e41r3JsBSWeoNgDthYJuYvO5FUu8yn6qxVIJm2X2BHlLXwiq5b7NACYU2a9JJb98jkyEVGhPei1dEe.jpg",
        "xGBZCmYXuev5UXpwjJlw4BTWwSzstQgpgBCvEstPnKbkD6dK05EWhv1Bg8ABpFDTn0ltgT1jGDMMbI5d42uVhs3pKGF2hMjA2LPOC8EboexBLPrpiljOrMjhbmcGZ0uT.jpg",
        "StiI9R0ovrhmv1ZxNlIYw99phNp3bUitpjJD2e0xDjMztUKZKEuOHE8npuSsZYpW4ugjcPznOS9llG6l9cYaoj0zeMUDcphisyPlELdtQdu47vt7wTWyjW2hWu4oAahG.jpg",
        "aqJmaHjFUjvPZK5moKjv2swceZLlUsRWaVOqqsDgPEt2vuvJrLWLQx3qWaaaUnoY1BC5Bh2cugIQT3fFzDhxfJjLQJJ61mhJpdjpM1AI9sDfeuCFzrjNtq21Zzswoypy.jpg",
        "Fe5jlI2KGXGoitktU0328Ca7OapYWKabt1a1pWy4jXRogqP8s0FFM7NMFC8XxS9MYaTKc91uwcuBzypKwpRywn7scJJmUsf2EzHn6WPzGtIVx2tTD1WtA8KolGrS5kMc.jpg",
        "KCiWadPdLsc1xZm0OeLF5EzdrBsT3GWffHdjLuSpTA62oiA3UVqQml5g2XVfwwQwVSMTuWZCut1njQegTVr0qgy9jEoflRmrTEaFqQ1BTYYXTzv5ohD7UbejiNzORV8h.jpg",
        "RC74A3cXx9GDFYSkGjds4OnQRROA5s4m5bO4VdKq9TpuV97MeZhBlIAlOYyKhJ2deo3igr46OlgsMm6WoZPxrnXVHmaTtZhjF0TEtHx9bdvGWXXk0uTg6HSP1Wx1k8vy.jpg",
        "DedBPlZvNu1QQvnFfumWifyLOtZwVhLKMnbWfkylPvDopqFqF8utuM6oQ04hvTWldeDpq0clCJuLjqwxatL09XsK0KVQFnDvKnqJaPemi1L2rMyegSYe5UwXcWiFeSuT.jpg",
        "DKQVQvwWBAeznU0QNt0oXfOtyGnIDLIqho24U8hposXyKSdDH7wg7jGWJ0AFJkXeTqYL8itQNgFuNIz74kiWRvbZ3YidhrkCBXRspqn8KH7HMpu67M4S1bN8EZLWGIEl.jpg",
        "GRDBw321FmqGmeWphwLRj0ug68K5V4uZ9Vjta82xB5GCZ7qQDE1n5NdIi88bW5IK0JvvIZLiORO2buirS76azPBCHh8m3IebWf7VNcfhAP7gsUsaklCRPOwqvlyhrh0p.jpg",
        "tpejksNdtt7nPZd4m9PeCiVBjV4U4Y2LvewC4krN4TTxQLaRBe7htQAb76aQO8J0gm1e88aEXPc9Nbk5xHTfoMjEkEySc9XVr3a2qitPAPQLeqGQfl6SdXxA7YbeVTQP.jpg",
        "4QWbznka0A2Fni4CP3Wa0hb3FylCaWGY6AuthWiQepYDZBi98BYsOJlQX8QTTVsiMZthVqnlVkWgGmLO9CHZJveNSU0l8BOVAFyF5J0ovDfTYHvd5kinVdJ6LCfgL0fx.jpg",
        "NOX0Z9IpSD3cqjTEd5XktuFTCHpFY9im2RNhWZBgHeRJX4WzDPefdrguQtPkLQBurZJeCwVwII127bfBgXoq2XLek0lwrzIvYnUWiQFvKVvVRWbL3YQM2fcc7OprzuSv.jpg",
        "J87fDFr1wGGaDsRuZG5zc4X2jCY0Wm6hT46LjKD65D1u1OLBTDSRuTAu0YDNhX8Zkq8dJNWil3wL1ku432LwXoteiuX2TsK1gnQ2ix68IBnVoPGkycS77z5q2BZUPq1q.jpg",
        "vyCBE5GqxOQDDyedLFJxfgna4eIzu581WZGmz9Qybswwf7uJfd3diX8H9eEhEB6GKgF3bP53kNSInvKfc5J15uC5pPieCzpyuMnEL6hd0yNVUsGMzD78hOwyWnm1rFDH.jpg",
        "7ytpj4PqGXMdiY4bdquMV5k6fuxd68kB24PcOT3LJZv9ccKVuHwUDYEW9BgIeMHVeXRy9zeaGyzK2Oqf3KwgnMcS2YhCB0Muv9nZpjRVbyKzm223P1EPTHBE24qNBGQv.jpg",
        "nIvFIQQzXpRE5f5issGap2GDsL8XGFFNmUjoBtlUO6bMUD2coAlvVNeT3E2IU9yMCCgD79qP1bL4XlQ5Anu2hJuOBy5F2WdNJFhvBFHcR799T3TxezRqpq9BEZG2C6oy.jpg",
        "fyBYPcqH4khFXRB1QKBR9Hp4T6XOlSy5vV4Xkj9A242j2Y1WjnwXQcKM2z9P5qKMB8jfDGZjwiiT9JPyxGFsaMiKJfC3KpX9AIrsrUxykq8uuOdOzZuPhd5yEBKp15aH.jpg",
        "CF1Rk4eLKusk3S3QHp9X0I5O5u0FbxgYQacOMDJHmlTCWrvADhq2Z1Gr4YZmFIFqEWZdDQq4TtCUygE0Cc0KyuV2qStbp44hpnOHYQtTOG0C638L4UkDKpKcg15IKYwU.jpg",
        "Q5F6N3Qcn7MyIHwwSNpchEMNYP5RR8SAfASHUO5NCAMnasNYgBKTsReMXwy1lefPMgPiirCwLsBIdwU6ESfYiiYT3t5RECUbzJkDZcIhDKHuiWlIOwhhi5jJfdfmKvIt.jpg",
        "lPyFTFPgz8qfsEL8DhRCYkRehebcCLx1gOGoNowFBJpCRcbgk94T5kscRnMx1RZAMhgGGJd07BP5LbJCRG4jliAJKGRh2nR0HVvPz6boVokqldGxWyrnHbqAjsMsO8kz.jpg",
        "9XmMMWMbF80JuFI021wglIW28XAawhmDGXi0CmZs8scfBmxoEtRwOLrMFl0HyFS9p0wT15lGX77xgWUq2lHYIUlogXEiCk9w1tR0QlRUUuto5kFLDFG9CnZgnJeXQqUs.jpg",
        "lJGG6BPv1t9Fe70GWMeRZzeTE23gqerBCKRJQJx7A1mv8pLyGTlkkKdE1mZjxwfBKAHQjDE4HIM1tPENr8w929XHySk77anTEMjt3RwYEXsbPDJoFWTxCkkxNmfugZAJ.jpg",
        "eAFcLmAP6mHUGm0gUsjMCKVOkCm7MYiAptCYezYDvIN8F2IYa16DtNeYrFtAnVGan2VE39jtuNlOn8ZwvIswrJbHJoFzHshfZO95ERnxo9Hjb9nxvR6LNMU7Z7tNC4he.jpg",
        "QxlKMIgPz8M7dQXTYI6zFI6siK1l9LVqehP2rfHA3t36vtxzXarfIgFQo6WQgir12k1URzBWTxDDkfhG9B2RR7pZS3lyciM2rS7xVrZTujdLOoS04en4G9JcimhCKlrr.jpg",
        "OrIMCcrqp59yS2JTvoTAKx92699b43RGBWHA8a8DZs5TWK7RLY4b7dc78oIOMvaQQ1mySHhsrRXMPECqGHr79CRXjY9VcGJu0UbKNivoMvIcMbuUsETSbfFdhpWQEDOu.jpg",
        "aESVttHrpOcmox35uYI48wEtmdt4E3QkjWbZTzQNiaSwHqYOL5zz7B1gFiph1RW3alARKQkcGBMxsDsE029bF4P5XlOOxTrdfujesyaYQsSRCRB9eGtnTn0bcQ9cOnJs.jpg",
        "8SW5hDBQ2uc7QRyEZtm9KBpbCd8SpL2wE8pfggSENTxCv657wVwHpbPp8e1729mIxXBZ0o5QVUyH6iE9J3wdQbVtCUCzakVPGu2CvjKwgIKzauZwW3jQVgtYdNi0GcZ8.jpg",
        "ujPC3OZw3GOLJsu0MwDEykwH9kLUf02QDAZSb6PaOm276yApUfS2O7aKtXzyliixKwEXFzUC4W1nRUkmgI5wra5u0gkySYgtnYQIz7IQ2dkxLYUhZBhvakGgJk2rDtUY.jpg",
        "GQuzGhacNwbklgl9xSnhfXw3D3aiGHR3hE42QnivvYOdUvqfgktilndNgzWiclKbkyIBz6HvwPd6LtG42Hw4M445mLMcy4l889fNIKn5shDm83Gm7jslZqKL4VWbR60B.jpg",
        "BeBKSJNghjWFkkDwfeWQuJbSqBXCeLvtwsejK2vS4EQfyRL3MAr8Rg1KkjP3ubxgvtMakraB5FYaPuqXtMzDxA44lwR6DOtokHV9iha3rOiejeNwlm4agHJ4rKv9hVQ3.jpg",
        "nTwi1suvPN6GoBv25atc9KhvGoczZkkmrT30xsQmBTlcIXYRnrLMhSITJLtOBBHrAePVrAet4T3FD2cEsnxadjt8rEwbkgeKxNlckZufxGN7rDVYJ3jr8zseytcfvnqy.jpg",
        "4IIrU7mw7RAzx8pkn2ymYvCXgquhyYd1ZqV1S9GQvG7ecsFzRUHmfwBjerOx1vgcUWW2sNdMwuwGg2JUiLYEahS86GC22tn0hWhKcXV2VdXOPBe0cgv20sNtJVIphZzJ.jpg"
    };

    /// <summary>
    /// Gets a default profile picture path for a user
    /// </summary>
    /// <param name="userId">ID of the user to get the default
    /// profile photo path for</param>
    /// <returns>Profile photo path</returns>
    public static string GetDefaultProfilePhoto(long userId)
    {
        var index = (int)(userId % _defaultProfilePhotos.Length);

        return _defaultProfilePhotos[index];
    }

    /// <summary>
    /// Gets a default cover picture path
    /// </summary>
    /// <returns>Cover photo path</returns>
    public static string GetDefaultCoverPhoto()
    {
        var index = new Random().Next(_defaultCoverPhotos.Length - 1);

        return _defaultCoverPhotos[index];
    }
}
