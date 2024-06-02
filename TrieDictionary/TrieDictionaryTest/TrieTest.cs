namespace TrieDictionaryTest;

[TestClass]
public class TrieTest
{
    // Test that a word is inserted in the trie
    [TestMethod]
    public void InsertWord()
    {
        Trie trie = new Trie();
        trie.Insert("hello");
        Assert.IsTrue(trie.Search("hello"));
    }
    // Test that a word is not inserted twice in the trie
    [TestMethod]
    public void InsertWordTwice()
    {
        Trie trie = new Trie();
        trie.Insert("hello");
        trie.Insert("hello");
        Assert.IsTrue(trie.Search("hello"));
    }

    // Test that a word is deleted from the trie
    [TestMethod]
    public void DeleteWord()
    {
        Trie trie = new Trie();
        trie.Insert("hello");
        trie.Delete("hello");
        Assert.IsFalse(trie.Search("hello"));
    }

    // Test that a word is not deleted from the trie if it is not present
    [TestMethod]
    public void DeleteNonExistentWord()
    {
        Trie trie = new Trie();
        trie.Insert("hello");
        trie.Delete("world");
        Assert.IsTrue(trie.Search("hello"));
    }

    // Test that a word is deleted from the trie if it is a prefix of another word
    [TestMethod]
    public void DeletePrefixWord()
    {
        Trie trie = new Trie();
        trie.Insert("hello");
        trie.Insert("hell");
        trie.Delete("hell");
        Assert.IsTrue(trie.Search("hello"));
        Assert.IsFalse(trie.Search("hell"));
    }

    // Test AutoSuggest for the prefix "cat" not present in the 
    // trie containing "catastrophe", "catatonic", and "caterpillar"
    [TestMethod]
    public void TestAutoSuggest()
    {
        Trie dictionary = new Trie();
        dictionary.Insert("catastrophe");
        dictionary.Insert("catatonic");
        dictionary.Insert("caterpillar");
        List<string> suggestions = dictionary.AutoSuggest("cat");
        Assert.AreEqual(3, suggestions.Count);
        Assert.AreEqual("catastrophe", suggestions[0]);
        Assert.AreEqual("catatonic", suggestions[1]);
        Assert.AreEqual("caterpillar", suggestions[2]);
    }

    // Test GetSpellingSuggestions for a word not present in the trie
    [TestMethod]
    public void TestGetSpellingSuggestions()
    {
        Trie dictionary = new Trie();
        dictionary.Insert("cat");
        dictionary.Insert("caterpillar");
        dictionary.Insert("catastrophe");
        List<string> suggestions = dictionary.GetSpellingSuggestions("caterpiller");
        Assert.AreEqual(1, suggestions.Count);
        Assert.AreEqual("caterpillar", suggestions[0]);
    }







}