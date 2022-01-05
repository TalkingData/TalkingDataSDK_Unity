using UnityEngine;


public class TalkingDataSearch
{
#if UNITY_ANDROID
    public AndroidJavaObject javaObj;
#endif

#if UNITY_IPHONE
    private string category;
    private string content;
#if TD_RETAIL
    private string itemId;
    private string itemLocationId;
#endif
#if TD_TOUR
    private string destination;
    private string origin;
    private long startDate;
    private long endDate;
#endif
#endif

    public static TalkingDataSearch CreateSearch()
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
            TalkingDataSearch search = new TalkingDataSearch();
#if UNITY_ANDROID
            AndroidJavaClass javaClass = new AndroidJavaClass("com.tendcloud.tenddata.TalkingDataSearch");
            search.javaObj = javaClass.CallStatic<AndroidJavaObject>("createSearch");
#endif
            return search;
        }
        return null;
    }

    // 搜索分类
    public TalkingDataSearch SetCategory(string category)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                javaObj.Call<AndroidJavaObject>("setCategory", category);
            }
#endif
#if UNITY_IPHONE
            this.category = category;
#endif
        }
        return this;
    }

    // 搜索内容
    public TalkingDataSearch SetContent(string content)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                javaObj.Call<AndroidJavaObject>("setContent", content);
            }
#endif
#if UNITY_IPHONE
            this.content = content;
#endif
        }
        return this;
    }

#if TD_RETAIL
    // 商品 ID（eg.酒店/汽车）；至多64字符，支持数字+字母
    public TalkingDataSearch SetItemId(string itemId)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                javaObj.Call<AndroidJavaObject>("setItemId", itemId);
            }
#endif
#if UNITY_IPHONE
            this.itemId = itemId;
#endif
        }
        return this;
    }

    // 商品位置 ID（eg.求职招聘/教育行业）；至多64字符，支持数字+字母
    public TalkingDataSearch SetItemLocationId(string itemLocationId)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                javaObj.Call<AndroidJavaObject>("setItemLocationId", itemLocationId);
            }
#endif
#if UNITY_IPHONE
            this.itemLocationId = itemLocationId;
#endif
        }
        return this;
    }
#endif

#if TD_TOUR
    // 目的地城市 ID；至多64字符，支持数字+字母
    public TalkingDataSearch SetDestination(string destination)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                javaObj.Call<AndroidJavaObject>("setDestination", destination);
            }
#endif
#if UNITY_IPHONE
            this.destination = destination;
#endif
        }
        return this;
    }

    // 出发地城市 ID；至多64字符，支持数字+字母
    public TalkingDataSearch SetOrigin(string origin)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                javaObj.Call<AndroidJavaObject>("setOrigin", origin);
            }
#endif
#if UNITY_IPHONE
            this.origin = origin;
#endif
        }
        return this;
    }

    // 业务事件起始日期（eg.航班出发日期）
    public TalkingDataSearch SetStartDate(long startDate)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                javaObj.Call<AndroidJavaObject>("setStartDate", startDate);
            }
#endif
#if UNITY_IPHONE
            this.startDate = startDate;
#endif
        }
        return this;
    }

    // 业务事件截止日期（eg.航班返程日期）
    public TalkingDataSearch SetEndDate(long endDate)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                javaObj.Call<AndroidJavaObject>("setEndDate", endDate);
            }
#endif
#if UNITY_IPHONE
            this.endDate = endDate;
#endif
        }
        return this;
    }
#endif

#if UNITY_IPHONE
    public override string ToString()
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
            string searchStr = "{\"category\":\"" + category + "\""
                             + ",\"content\":\"" + content + "\""
#if TD_RETAIL
                             + ",\"itemId\":\"" + itemId + "\""
                             + ",\"itemLocationId\":\"" + itemLocationId + "\""
#endif
#if TD_TOUR
                             + ",\"destination\":\"" + destination + "\""
                             + ",\"origin\":\"" + origin + "\""
                             + ",\"startDate\":" + startDate
                             + ",\"endDate\":" + endDate
#endif
                             + "}";
            return searchStr;
        }
        return null;
    }
#endif
}
