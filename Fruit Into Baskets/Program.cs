// See https://aka.ms/new-console-template for more information
var fruits = new int[] { 1, 2, 1, 3, 2, 2, 3, 4 };
Solution s = new Solution();
var answer = s.TotalFruit(fruits);  
Console.WriteLine(answer);

public class Solution
{
  public int TotalFruit(int[] fruits)
  {
    // i and j are our left and right boundary
    int ans = 1;
    int length = fruits.Length;
    int left = 0;
    int right = 0;
    // map is used to store occurance of each type fruits.
    var map = new Dictionary<int, int>();
    while (left < length && right < length)
    {
      var cur = fruits[right];
      if (!map.ContainsKey(cur)) map.Add(cur, 0);
      map[cur]++;
      // when we have seen more than 2 types fruits in our current left to right boundary, we will try to remove fruits from left side until in map we have only less than 3 types fruits 
      while (map.Count > 2 && left < length)
      {
        // remove fruits from left side
        var key = fruits[left];
        map[key]--;
        // when no more of this type fruit present will delete the key
        if (map[key] == 0) map.Remove(key);
        // more to right
        left++;
      }
      // get the sum of two types pf fruits occurance
      var sum = map.Values.Sum();
      // update max
      ans = Math.Max(ans, sum);
      // move to right
      right++;
    }

    return ans;
  }
}