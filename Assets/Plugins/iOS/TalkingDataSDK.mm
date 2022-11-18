#import "TalkingDataSDK.h"

// #define TD_RETAIL       // 电商零售
// #define TD_GAME         // 游戏娱乐
// #define TD_FINANCE      // 金融借贷
// #define TD_TOUR         // 旅游出行
// #define TD_ONLINEEDU    // 在线教育
// #define TD_READING      // 小说阅读
// #define TD_OTHER        // 其他行业

// Converts C style string to NSString
static NSString *TDCreateNSString(const char *string) {
    return string ? [NSString stringWithUTF8String:string] : nil;
}

static char *tdDeviceId = NULL;

extern "C" {
#pragma GCC diagnostic ignored "-Wmissing-prototypes"

void TDInit(const char *appId, const char *channelId, const char *custom) {
    if ([TalkingDataSDK respondsToSelector:@selector(setFrameworkTag:)]) {
        [TalkingDataSDK performSelector:@selector(setFrameworkTag:) withObject:@2];
    }
    [TalkingDataSDK init:TDCreateNSString(appId)
               channelId:TDCreateNSString(channelId)
                  custom:TDCreateNSString(custom)];
}

void TDBackgroundSessionEnabled() {
    [TalkingDataSDK backgroundSessionEnabled];
}

const char *TDGetDeviceId() {
    if (!tdDeviceId) {
        NSString *deviceId = [TalkingDataSDK getDeviceId];
        tdDeviceId = (char *)calloc(deviceId.length + 1, sizeof(char));
        strcpy(tdDeviceId, deviceId.UTF8String);
    }
    return tdDeviceId;
}

void TDSetVerboseLogDisable() {
    [TalkingDataSDK setVerboseLogDisable];
}

void TDSetLocation(double latitude, double longitude) {
    [TalkingDataSDK setLatitude:latitude longitude:longitude];
}

void TDOnPageBegin(const char *pageName) {
    [TalkingDataSDK onPageBegin:TDCreateNSString(pageName)];
}

void TDOnPageEnd(const char *pageName) {
    [TalkingDataSDK onPageEnd:TDCreateNSString(pageName)];
}

void TDOnReceiveDeepLink(const char *url) {
    [TalkingDataSDK onReceiveDeepLink:[NSURL URLWithString:TDCreateNSString(url)]];
}

void TDOnRegister(const char *profileId, const char *profileJson, const char *invitationCode) {
    NSString *profileStr = TDCreateNSString(profileJson);
    NSData *profileData = [profileStr dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *profileDic = [NSJSONSerialization JSONObjectWithData:profileData options:0 error:nil];
    TalkingDataProfile *profile = [TalkingDataProfile createProfile];
    profile.name = [profileDic objectForKey:@"name"];
    NSNumber *typeNum  = [profileDic objectForKey:@"type"];
    if ([typeNum isKindOfClass:[NSNumber class]]) {
        profile.type = (TalkingDataProfileType)[typeNum unsignedIntegerValue];
    }
    NSNumber *genderNum = [profileDic objectForKey:@"gender"];
    if ([genderNum isKindOfClass:[NSNumber class]]) {
        profile.gender = (TalkingDataGender)[genderNum unsignedIntegerValue];
    }
    NSNumber *ageNum = [profileDic objectForKey:@"age"];
    if ([ageNum isKindOfClass:[NSNumber class]]) {
        profile.age = [ageNum intValue];
    }
    profile.property1 = [profileDic objectForKey:@"property1"];
    profile.property2 = [profileDic objectForKey:@"property2"];
    profile.property3 = [profileDic objectForKey:@"property3"];
    profile.property4 = [profileDic objectForKey:@"property4"];
    profile.property5 = [profileDic objectForKey:@"property5"];
    profile.property6 = [profileDic objectForKey:@"property6"];
    profile.property7 = [profileDic objectForKey:@"property7"];
    profile.property8 = [profileDic objectForKey:@"property8"];
    profile.property9 = [profileDic objectForKey:@"property9"];
    profile.property10 = [profileDic objectForKey:@"property10"];
    [TalkingDataSDK onRegister:TDCreateNSString(profileId)
                       profile:profile
                invitationCode:TDCreateNSString(invitationCode)];
}

void TDOnLogin(const char *profileId, const char *profileJson) {
    NSString *profileStr = TDCreateNSString(profileJson);
    NSData *profileData = [profileStr dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *profileDic = [NSJSONSerialization JSONObjectWithData:profileData options:0 error:nil];
    TalkingDataProfile *profile = [TalkingDataProfile createProfile];
    profile.name = [profileDic objectForKey:@"name"];
    NSNumber *typeNum  = [profileDic objectForKey:@"type"];
    if ([typeNum isKindOfClass:[NSNumber class]]) {
        profile.type = (TalkingDataProfileType)[typeNum unsignedIntegerValue];
    }
    NSNumber *genderNum = [profileDic objectForKey:@"gender"];
    if ([genderNum isKindOfClass:[NSNumber class]]) {
        profile.gender = (TalkingDataGender)[genderNum unsignedIntegerValue];
    }
    NSNumber *ageNum = [profileDic objectForKey:@"age"];
    if ([ageNum isKindOfClass:[NSNumber class]]) {
        profile.age = [ageNum intValue];
    }
    profile.property1 = [profileDic objectForKey:@"property1"];
    profile.property2 = [profileDic objectForKey:@"property2"];
    profile.property3 = [profileDic objectForKey:@"property3"];
    profile.property4 = [profileDic objectForKey:@"property4"];
    profile.property5 = [profileDic objectForKey:@"property5"];
    profile.property6 = [profileDic objectForKey:@"property6"];
    profile.property7 = [profileDic objectForKey:@"property7"];
    profile.property8 = [profileDic objectForKey:@"property8"];
    profile.property9 = [profileDic objectForKey:@"property9"];
    profile.property10 = [profileDic objectForKey:@"property10"];
    [TalkingDataSDK onLogin:TDCreateNSString(profileId)
                    profile:profile];
}

void TDOnProfileUpdate(const char *profileJson) {
    NSString *profileStr = TDCreateNSString(profileJson);
    NSData *profileData = [profileStr dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *profileDic = [NSJSONSerialization JSONObjectWithData:profileData options:0 error:nil];
    TalkingDataProfile *profile = [TalkingDataProfile createProfile];
    profile.name = [profileDic objectForKey:@"name"];
    NSNumber *typeNum  = [profileDic objectForKey:@"type"];
    if ([typeNum isKindOfClass:[NSNumber class]]) {
        profile.type = (TalkingDataProfileType)[typeNum unsignedIntegerValue];
    }
    NSNumber *genderNum = [profileDic objectForKey:@"gender"];
    if ([genderNum isKindOfClass:[NSNumber class]]) {
        profile.gender = (TalkingDataGender)[genderNum unsignedIntegerValue];
    }
    NSNumber *ageNum = [profileDic objectForKey:@"age"];
    if ([ageNum isKindOfClass:[NSNumber class]]) {
        profile.age = [ageNum intValue];
    }
    profile.property1 = [profileDic objectForKey:@"property1"];
    profile.property2 = [profileDic objectForKey:@"property2"];
    profile.property3 = [profileDic objectForKey:@"property3"];
    profile.property4 = [profileDic objectForKey:@"property4"];
    profile.property5 = [profileDic objectForKey:@"property5"];
    profile.property6 = [profileDic objectForKey:@"property6"];
    profile.property7 = [profileDic objectForKey:@"property7"];
    profile.property8 = [profileDic objectForKey:@"property8"];
    profile.property9 = [profileDic objectForKey:@"property9"];
    profile.property10 = [profileDic objectForKey:@"property10"];
    [TalkingDataSDK onProfileUpdate:profile];
}

void TDOnCreateCard(const char *profileId, const char *method, const char *content) {
    [TalkingDataSDK onCreateCard:TDCreateNSString(profileId)
                          method:TDCreateNSString(method)
                         content:TDCreateNSString(content)];
}

void TDOnFavorite(const char *category, const char *content) {
    [TalkingDataSDK onFavorite:TDCreateNSString(category)
                       content:TDCreateNSString(content)];
}

void TDOnShare(const char *profileId, const char *content) {
    [TalkingDataSDK onShare:TDCreateNSString(profileId)
                    content:TDCreateNSString(content)];
}

void TDOnPunch(const char *profileId, const char *punchId) {
    [TalkingDataSDK onPunch:TDCreateNSString(profileId)
                    punchId:TDCreateNSString(punchId)];
}

void TDOnSearch(const char *searchJson) {
    NSString *searchStr = TDCreateNSString(searchJson);
    NSData *searchData = [searchStr dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *searchDic = [NSJSONSerialization JSONObjectWithData:searchData options:0 error:nil];
    TalkingDataSearch *search = [TalkingDataSearch createSearch];
    search.category = [searchDic objectForKey:@"category"];
    search.content = [searchDic objectForKey:@"content"];
#ifdef TD_RETAIL
    search.itemId = [searchDic objectForKey:@"itemId"];
    search.itemLocationId = [searchDic objectForKey:@"itemLocationId"];
#endif
#ifdef TD_TOUR
    search.destination = [searchDic objectForKey:@"destination"];
    search.origin = [searchDic objectForKey:@"origin"];
    search.startDate = [[searchDic objectForKey:@"startDate"] longLongValue];
    search.endDate = [[searchDic objectForKey:@"endDate"] longLongValue];
#endif
    [TalkingDataSDK onSearch:search];
}

#if (defined(TD_RETAIL) || defined(TD_FINANCE) || defined(TD_TOUR) || defined(TD_ONLINEEDU))
void TDOnContact(const char *profileId, const char *content) {
    [TalkingDataSDK onContact:TDCreateNSString(profileId)
                      content:TDCreateNSString(content)];
}
#endif

#if (defined(TD_GAME) || defined(TD_TOUR) || defined(TD_ONLINEEDU) || defined(TD_READING) || defined(TD_OTHER))
void TDOnPay(const char *profileId, const char *orderId, int amount, const char *currencyType, const char *paymentType, const char *itemId, int itemCount) {
    [TalkingDataSDK onPay:TDCreateNSString(profileId)
                  orderId:TDCreateNSString(orderId)
                   amount:amount
             currencyType:TDCreateNSString(currencyType)
              paymentType:TDCreateNSString(paymentType)
                   itemId:TDCreateNSString(itemId)
                itemCount:itemCount];
}
#endif

#if (defined(TD_RETAIL) || defined(TD_FINANCE) || defined(TD_TOUR) || defined(TD_ONLINEEDU))
void TDOnChargeBack(const char *profileId, const char *orderId, const char *reason, const char *type) {
    [TalkingDataSDK onChargeBack:TDCreateNSString(profileId)
                         orderId:TDCreateNSString(orderId)
                          reason:TDCreateNSString(reason)
                            type:TDCreateNSString(type)];
}
#endif

#if (defined(TD_FINANCE) || defined(TD_ONLINEEDU))
void TDOnReservation(const char *profileId, const char *reservationId, const char *category, int amount, const char *term) {
    [TalkingDataSDK onReservation:TDCreateNSString(profileId)
                    reservationId:TDCreateNSString(reservationId)
                         category:TDCreateNSString(category)
                           amount:amount
                             term:TDCreateNSString(term)];
}
#endif

#if (defined(TD_RETAIL) || defined(TD_TOUR))
void TDOnBooking(const char *profileId, const char *bookingId, const char *category, int amount, const char *content) {
    [TalkingDataSDK onBooking:TDCreateNSString(profileId)
                    bookingId:TDCreateNSString(bookingId)
                     category:TDCreateNSString(category)
                       amount:amount
                      content:TDCreateNSString(content)];
}
#endif

#ifdef TD_RETAIL
void TDOnViewItem(const char *itemId, const char *category, const char *name, int unitPrice) {
    [TalkingDataSDK onViewItem:TDCreateNSString(itemId)
                      category:TDCreateNSString(category)
                          name:TDCreateNSString(name)
                     unitPrice:unitPrice];
}

void TDOnAddItemToShoppingCart(const char *itemId, const char *category, const char *name, int unitPrice, int amount) {
    [TalkingDataSDK onAddItemToShoppingCart:TDCreateNSString(itemId)
                                   category:TDCreateNSString(category)
                                       name:TDCreateNSString(name)
                                  unitPrice:unitPrice
                                     amount:amount];
}

void TDOnViewShoppingCart(const char *shoppingCartJson) {
    NSString *shoppingCartStr = TDCreateNSString(shoppingCartJson);
    NSData *shoppingCartData = [shoppingCartStr dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *shoppingCartDic = [NSJSONSerialization JSONObjectWithData:shoppingCartData options:0 error:nil];
    TalkingDataShoppingCart *shoppingCart = [TalkingDataShoppingCart createShoppingCart];
    NSArray *items = shoppingCartDic[@"items"];
    for (NSDictionary *item in items) {
        [shoppingCart addItem:item[@"itemId"]
                     category:item[@"category"]
                         name:item[@"name"]
                    unitPrice:[item[@"unitPrice"] intValue]
                       amount:[item[@"amount"] intValue]];
    }
    [TalkingDataSDK onViewShoppingCart:shoppingCart];
}

void TDOnPlaceOrder(const char *orderJson, const char *profileId) {
    NSString *orderStr = TDCreateNSString(orderJson);
    NSData *orderData = [orderStr dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *orderDic = [NSJSONSerialization JSONObjectWithData:orderData options:0 error:nil];
    TalkingDataOrder *order = [TalkingDataOrder createOrder:orderDic[@"orderId"]
                                                      total:[orderDic[@"total"] intValue]
                                               currencyType:orderDic[@"currencyType"]];
    NSArray *items = orderDic[@"items"];
    for (NSDictionary *item in items) {
        [order addItem:item[@"itemId"]
              category:item[@"category"]
                  name:item[@"name"]
             unitPrice:[item[@"unitPrice"] intValue]
                amount:[item[@"amount"] intValue]];
    }
    [TalkingDataSDK onPlaceOrder:order
                      profileId:TDCreateNSString(profileId)];
}

void TDOnOrderPaySucc(const char *orderJson, const char *paymentType, const char *profileId) {
    NSString *orderStr = TDCreateNSString(orderJson);
    NSData *orderData = [orderStr dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *orderDic = [NSJSONSerialization JSONObjectWithData:orderData options:0 error:nil];
    TalkingDataOrder *order = [TalkingDataOrder createOrder:orderDic[@"orderId"]
                                                      total:[orderDic[@"total"] intValue]
                                               currencyType:orderDic[@"currencyType"]];
    NSArray *items = orderDic[@"items"];
    for (NSDictionary *item in items) {
        [order addItem:item[@"itemId"]
              category:item[@"category"]
                  name:item[@"name"]
             unitPrice:[item[@"unitPrice"] intValue]
                amount:[item[@"amount"] intValue]];
    }
    [TalkingDataSDK onOrderPaySucc:order
                       paymentType:TDCreateNSString(paymentType)
                        profileId:TDCreateNSString(profileId)];
}

void TDOnCancelOrder(const char *orderJson) {
    NSString *orderStr = TDCreateNSString(orderJson);
    NSData *orderData = [orderStr dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *orderDic = [NSJSONSerialization JSONObjectWithData:orderData options:0 error:nil];
    TalkingDataOrder *order = [TalkingDataOrder createOrder:orderDic[@"orderId"]
                                                      total:[orderDic[@"total"] intValue]
                                               currencyType:orderDic[@"currencyType"]];
    NSArray *items = orderDic[@"items"];
    for (NSDictionary *item in items) {
        [order addItem:item[@"itemId"]
              category:item[@"category"]
                  name:item[@"name"]
             unitPrice:[item[@"unitPrice"] intValue]
                amount:[item[@"amount"] intValue]];
    }
    [TalkingDataSDK onCancelOrder:order];
}
#endif

#ifdef TD_FINANCE
void TDOnCredit(const char *profileId, int amount, const char *content) {
    [TalkingDataSDK onCredit:TDCreateNSString(profileId)
                      amount:amount
                     content:TDCreateNSString(content)];
}

void TDOnTransaction(const char *profileId, const char *transactionJson) {
    NSString *transactionStr = TDCreateNSString(transactionJson);
    NSData *transactionData = [transactionStr dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *transactionDic = [NSJSONSerialization JSONObjectWithData:transactionData options:0 error:nil];
    TalkingDataTransaction *transaction = [TalkingDataTransaction createTransaction];
    transaction.transactionId = [transactionDic objectForKey:@"transactionId"];
    transaction.category = [transactionDic objectForKey:@"category"];
    transaction.amount = [[transactionDic objectForKey:@"amount"] intValue];
    transaction.personA = [transactionDic objectForKey:@"personA"];
    transaction.personB = [transactionDic objectForKey:@"personB"];
    transaction.startDate = [[transactionDic objectForKey:@"startDate"] longValue];
    transaction.endDate = [[transactionDic objectForKey:@"endDate"] longValue];
    transaction.currencyType = [transactionDic objectForKey:@"currencyType"];
    transaction.content = [transactionDic objectForKey:@"content"];
    [TalkingDataSDK onTransaction:TDCreateNSString(profileId)
                      transaction:transaction];
}
#endif

#ifdef TD_GAME
void TDOnCreateRole(const char *name) {
    [TalkingDataSDK onCreateRole:TDCreateNSString(name)];
}

void TDOnLevelPass(const char *profileId, const char *levelId) {
    [TalkingDataSDK onLevelPass:TDCreateNSString(profileId)
                        levelId:TDCreateNSString(levelId)];
}

void TDOnGuideFinished(const char *profileId, const char *content) {
    [TalkingDataSDK onGuideFinished:TDCreateNSString(profileId)
                            content:TDCreateNSString(content)];
}
#endif

#ifdef TD_ONLINEEDU
void TDOnLearn(const char *profileId, const char *course, long long begin, int duration) {
    [TalkingDataSDK onLearn:TDCreateNSString(profileId)
                     course:TDCreateNSString(course)
                      begin:begin
                   duration:duration];
}

void TDOnPreviewFinished(const char *profileId, const char *content) {
    [TalkingDataSDK onPreviewFinished:TDCreateNSString(profileId)
                              content:TDCreateNSString(content)];
}
#endif

#ifdef TD_READING
void TDOnRead(const char *profileId, const char *book, long long begin, int duration) {
    [TalkingDataSDK onRead:TDCreateNSString(profileId)
                      book:TDCreateNSString(book)
                     begin:begin
                  duration:duration];
}

void TDOnFreeFinished(const char *profileId, const char *content) {
    [TalkingDataSDK onFreeFinished:TDCreateNSString(profileId)
                           content:TDCreateNSString(content)];
}
#endif

#if (defined(TD_GAME) || defined(TD_ONLINEEDU))
void TDOnAchievementUnlock(const char *profileId, const char *achievementId) {
    [TalkingDataSDK onAchievementUnlock:TDCreateNSString(profileId)
                          achievementId:TDCreateNSString(achievementId)];
}
#endif

#if (defined(TD_FINANCE) || defined(TD_TOUR) || defined(TD_OTHER))
void TDOnBrowse(const char *profileId, const char *content, long long begin, int duration) {
    [TalkingDataSDK onBrowse:TDCreateNSString(profileId)
                     content:TDCreateNSString(content)
                       begin:begin
                    duration:duration];
}
#endif

#if (defined(TD_RETAIL) || defined(TD_FINANCE) || defined(TD_TOUR) || defined(TD_OTHER))
void TDOnTrialFinished(const char *profileId, const char *content) {
    [TalkingDataSDK onTrialFinished:TDCreateNSString(profileId)
                            content:TDCreateNSString(content)];
}
#endif

void TDOnEvent(const char *eventId, const char *parameters) {
    NSString *parameterStr = TDCreateNSString(parameters);
    NSDictionary *parameterDic = nil;
    if (parameterStr) {
        NSData *parameterData = [parameterStr dataUsingEncoding:NSUTF8StringEncoding];
        parameterDic = [NSJSONSerialization JSONObjectWithData:parameterData options:0 error:nil];
    }
    [TalkingDataSDK onEvent:TDCreateNSString(eventId)
                 parameters:parameterDic];
}

void TDSetGlobalKV(const char *key, const char *strVal, double numVal) {
    if (strVal != NULL) {
        [TalkingDataSDK setGlobalKV:TDCreateNSString(key)
                              value:TDCreateNSString(strVal)];
    } else {
        [TalkingDataSDK setGlobalKV:TDCreateNSString(key)
                              value:[NSNumber numberWithDouble:numVal]];
    }
}

void TDRemoveGlobalKV(const char *key) {
    [TalkingDataSDK removeGlobalKV:TDCreateNSString(key)];
}

#pragma GCC diagnostic warning "-Wmissing-prototypes"
}
