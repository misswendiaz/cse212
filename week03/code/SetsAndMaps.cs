using System.Data.Common;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE

        // Create a set
        var set = new HashSet<string>();
        var symmetricPairs = new List<string>();

        // Iterate through words
        foreach (var word in words)
        {
            // Add the word to the set
            set.Add(word);

            // Check if the word contains duplicates
            // If it does, ignore
            if (word[0] == word[1])
            {
                continue;
            }


            // Check if the reverse of the word is also in the set
            // If the reverse word is in the set
            var reverse = $"{word[1]}{word[0]}";

            if (set.Contains(reverse))
            {
                symmetricPairs.Add($"{word} & {reverse}");
            }
        }
        return symmetricPairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            // Get the degree from the degree column
            var degree = fields[3];

            // Initial degree count
            int count = 1;

            // Check if the degree is in the dictionary
            // If it is, increase the count by 1
            if (degrees.ContainsKey(degree))
            {
                degrees[degree] += 1;
            }
            // If not, add the degree in the dictionary with the initial count of 1
            else
            {
                degrees[degree] = count;
            }
        }
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE

        // Convert the words into a dictionary where the key is the letter and the value is the count
        var firstWord = new Dictionary<char, int>();
        var secondWord = new Dictionary<char, int>();


        foreach (char c in word1)
        {
            // Check if the character is a letter
            if (char.IsLetter(c))
            {
                // Check if it is in the dictionary [Note: It is not case sensitive]
                // If it is, update the count
                char key1 = c;
                char key1Lower = char.ToLower(key1);
                if (firstWord.ContainsKey(key1Lower))
                {
                    firstWord[key1Lower]++;
                }

                // If it is not, add it with a value/count of 1
                else
                {
                    firstWord[key1Lower] = 1;
                }
            }
        }

        foreach (char k in word2)
        {
            // Check if the character is a letter
            if (char.IsLetter(k))
            {
                // Check if it is in the dictionary [Note: It is not case sensitive]
                // If it is, update the count
                char key2 = k;
                char key2Lower = char.ToLower(key2);
                if (secondWord.ContainsKey(key2Lower))
                {
                    secondWord[key2Lower]++;
                }

                // If it is not, add it with a value/count of 1
                else
                {
                    secondWord[key2Lower] = 1;
                }
            }
        }

        // Check if the two dictionaries are equal

        bool areEqual = false;

        // Check if their counts are equal
        // If their counts are not equal, then they are not equal
        // Not anagrams
        // Result: False
        if (firstWord.Count != secondWord.Count)
        {
            areEqual = false;
        }

        // If their counts are equal
        // Check if their contents are exactly the same
        else
        {
            foreach (var entry in firstWord)
            {
                char key = entry.Key;
                int value = entry.Value;

                // Check if secondWord has the same key
                // If they don't have the same key, then the two dictionaries are not equal
                // Not anagrams
                // End the loop
                if (!secondWord.ContainsKey(key))
                {
                    areEqual = false;
                    break;
                }

                // If they have the same key, check if the value for those keys are also the same
                else
                {
                    // If their corresponding values are not equal, then the two dictionaries are not equal
                    // Not anagrams
                    // End the loop
                    if (value != secondWord[key])
                    {
                        areEqual = false;
                        break;
                    }

                    // If their values are equal, then the two dictionaries are equal, hence, an anagram
                    else
                    {
                        areEqual = true;
                    }
                }
            }
        }

        return areEqual;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>


    public static string[] EarthquakeDailySummary()
    {
        // USGS API URL
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        // Create an HTTP client
        using var client = new HttpClient();

        // Create an HTTP GET request
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

        // Send the request and get the response stream
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();

        // Convert the stream into readable text
        using var reader = new StreamReader(jsonStream);

        // Read the entire JSON response
        var json = reader.ReadToEnd();

        // Configure JSON deserialization options
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        // Deserialize JSON into C# objects
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.


        // Create a list
        List<string> earthquakeData = new List<string>();

        // Loop through each feature
        foreach (Feature feature in featureCollection.features)
        {
            // Read place
            string place = feature.properties.place;

            // Read magnitude
            decimal magnitude = feature.properties.mag;

            // Format a string
            string earthquakeDatum = $"{place} - Mag {magnitude}";

            // Add formatted string to a list
            earthquakeData.Add(earthquakeDatum);
        }


        // Return the list as an array
        string[] earthquakeDataArray = earthquakeData.ToArray();


        return earthquakeDataArray;
    }
}