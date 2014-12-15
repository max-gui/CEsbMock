using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CtripEsbAsmx
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld(string aa)
        {
            return "Hello World";
        }

        [WebMethod]
        public string Request(string requestXML)
        {
            var switchTmp = requestXML.Replace("\"", "'");
            switch (requestXML)
            {
                case @"<?xml version='1.0' encoding='utf-8'?>
<soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
  <soap:Body>
    <Request xmlns='http://tempuri.org/'>
      <requestXML>
        <?xml version='1.0'?>
        <Request>
        <Header Culture='cn' UserID='340101' RequestID='039477b6-431c-415e-9f56-753a4ca88aec' RequestType='Payment.Base.MerchantService.InqurieMerchantPayWay' ClientIP='172.16.146.78' AsyncRequest='false' Timeout='0' MessagePriority='3' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fws' UseMemoryQ='false' />
        <InqurieMerchantPayWayRequest>
        <MerchantID>200057</MerchantID>
        <ActionMode>All</ActionMode>
        <Language>En</Language>
        <ChargeMode>0</ChargeMode>
        <IsNeedRiskControl>true</IsNeedRiskControl>
        <CustomerID>13811118888</CustomerID>
        <OrderID>900234347</OrderID>
        </InqurieMerchantPayWayRequest>
        </Request>
      </requestXML>
    </Request>
  </soap:Body>
</soap:Envelope>":
                    return @"<?xml version='1.0' encoding='utf-8'?>
<soap:Envelope xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
  <soap:Body>
    <RequestResponse xmlns='http://tempuri.org/'>
      <RequestResult>
        <?xml version='1.0'?>
        <Response>
        <Header ServerIP='10.2.254.17' Culture='cn' ShouldRecordPerformanceTime='false' UserID='340101' RequestID='039477b6-431c-415e-9f56-753a4ca88aec' ResultCode='Success' ResultNo='0' ResultMsg='成功' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fws' />
        <InqurieMerchantPayWayResponse>
        <MerchantID>200057</MerchantID>
        <MerchantName>无线国内酒店</MerchantName>
        <ForeignCardCharge>0.00</ForeignCardCharge>
        <EnabledDCC>false</EnabledDCC>
        <UserInformation>
        <IsNeedCheckPhoneNo>true</IsNeedCheckPhoneNo>
        <IsNeedVerifyUserPhoneForCreditCard>true</IsNeedVerifyUserPhoneForCreditCard>
        </UserInformation>
        <IsWalletAvailable>true</IsWalletAvailable>
        <TMPayItems>
        <EnableTMPayType>3</EnableTMPayType>
        <EnableTMPayType>2</EnableTMPayType>
        <EnableTMPayType>1</EnableTMPayType>
        </TMPayItems>
        <PaymentCatalogs>
        <PaymentCatalogItem>
        <PaymentCatalogID>26</PaymentCatalogID>
        <CatalogName>钱包</CatalogName>
        <CatalogCode>CtripWallet</CatalogCode>
        <TipsToPay>钱包支付测试文案1</TipsToPay>
        <CatalogDescription>钱包支付测试文案</CatalogDescription>
        <PaymentWayItems>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>0</CreditCardType>
        <CreditCardBankID>0</CreditCardBankID>
        <PaymentWayID>CashAccountPay</PaymentWayID>
        <PaymentWayName>账户余额</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CAPAY</PrepayType>
        <SubPaySystem>9</SubPaySystem>
        <PaySystemName>现金账户支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption>账户余额(钱包)</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>0</CreditCardType>
        <CreditCardBankID>0</CreditCardBankID>
        <PaymentWayID>TMPAY_XING</PaymentWayID>
        <PaymentWayName>礼品卡-任我行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>TMPAY</PrepayType>
        <SubPaySystem>7</SubPaySystem>
        <PaySystemName>游票支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption>礼品卡-任我行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>0</CreditCardType>
        <CreditCardBankID>0</CreditCardBankID>
        <PaymentWayID>TMPAY_YOU</PaymentWayID>
        <PaymentWayName>礼品卡-任我游</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>TMPAY</PrepayType>
        <SubPaySystem>7</SubPaySystem>
        <PaySystemName>游票支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption>礼品卡-任我游</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>0</CreditCardType>
        <CreditCardBankID>0</CreditCardBankID>
        <PaymentWayID>TMPAY_ZHU</PaymentWayID>
        <PaymentWayName>礼品卡-任我住</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>TMPAY</PrepayType>
        <SubPaySystem>7</SubPaySystem>
        <PaySystemName>游票支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption>礼品卡-任我住</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        </PaymentWayItems>
        </PaymentCatalogItem>
        <PaymentCatalogItem>
        <PaymentCatalogID>2</PaymentCatalogID>
        <CatalogName>网上支付</CatalogName>
        <CatalogCode>EBank</CatalogCode>
        <TipsToPay />
        <CatalogDescription />
        <PaymentWayItems>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>0</CreditCardType>
        <CreditCardBankID>0</CreditCardBankID>
        <PaymentWayID>Alipay</PaymentWayID>
        <PaymentWayName>支付宝</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>ALPAY</PrepayType>
        <SubPaySystem>3</SubPaySystem>
        <PaySystemName>第三方支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption>&amp;lt;p class='paycredit_info'&amp;gt;
        注意事项：1.订单提交成功后会自动跳转至支付宝网站,请及时支付。&amp;lt;/p&amp;gt;
        &amp;lt;p class='paycredit_info2'&amp;gt;
        2.支付成功后我司会尽快安排出票,最终出票情况以我司确认为准。&amp;lt;/p&amp;gt;
        &amp;lt;p class='paycredit_info2'&amp;gt;
        3.提交后30分钟仍未付款,我司会取消订单。&amp;lt;/p&amp;gt;</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>0</CreditCardType>
        <CreditCardBankID>0</CreditCardBankID>
        <PaymentWayID>EB_CCB</PaymentWayID>
        <PaymentWayName>中国建设银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CBPAY</PrepayType>
        <SubPaySystem>3</SubPaySystem>
        <PaySystemName>第三方支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption>&amp;lt;p class='paycredit_info'&amp;gt;注意事项：信用卡单笔消费限额为5000元,当日累计消费限额为1万元；借记卡单笔和当日累计限额为5万元。&amp;lt;/p&amp;gt;</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>0</CreditCardType>
        <CreditCardBankID>0</CreditCardBankID>
        <PaymentWayID>EB_MobileAlipay</PaymentWayID>
        <PaymentWayName>移动版支付宝</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>MAPAY</PrepayType>
        <SubPaySystem>3</SubPaySystem>
        <PaySystemName>第三方支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>0</CreditCardType>
        <CreditCardBankID>0</CreditCardBankID>
        <PaymentWayID>WechatScanCode</PaymentWayID>
        <PaymentWayName>微信支付 </PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>WSCAN</PrepayType>
        <SubPaySystem>3</SubPaySystem>
        <PaySystemName>第三方支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <PromotionText>微信支付测试文案1（长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度</PromotionText>
        <Descrption>微信支付测试文案2（长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长度超长长）</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        </PaymentWayItems>
        </PaymentCatalogItem>
        <PaymentCatalogItem>
        <PaymentCatalogID>3</PaymentCatalogID>
        <CatalogName>现金</CatalogName>
        <CatalogCode>Cash</CatalogCode>
        <TipsToPay />
        <CatalogDescription>&amp;lt;p class='paycredit_info'&amp;gt;
        注意事项：您可前往以下地点支付现金。&amp;lt;/p&amp;gt;
        &amp;lt;p class='paycredit_info2'&amp;gt;
        1.上海（总部）：上海市长宁区福泉路99号1楼,电话：34064880&amp;lt;/p&amp;gt;
        &amp;lt;p class='paycredit_info2'&amp;gt;
        2.上海（国立分部）：北京西路1465号国立大厦1611室,电话：34064880*22198/22196/22199&amp;lt;/p&amp;gt;
        &amp;lt;p class='paycredit_info2'&amp;gt;
        3.北京：东城区东中街40号元嘉国际氏座3层303室。电话：010一64161515&amp;lt;/p&amp;gt;
        &amp;lt;p class='paycredit_info2'&amp;gt;
        4.广州：体育东路116-118号,财富广场西塔2402室（510620）,电话：020-83936393&amp;lt;/p&amp;gt;
        &amp;lt;p class='paycredit_info2'&amp;gt;
        5.深圳：深圳市罗湖区深南东路4003号世界金融中心人座30楼EF（联系人：徐立红(深圳)）,电话：0755-25981699*622&amp;lt;/p&amp;gt;
        &amp;lt;p class='paycredit_info2'&amp;gt;
        6.成都：成都市东大街紫东楼段11号东方广场5楼9号,电话：028-82005866&amp;lt;/p&amp;gt;</CatalogDescription>
        <PaymentWayItems>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>0</CreditCardType>
        <CreditCardBankID>0</CreditCardBankID>
        <PaymentWayID>Cash</PaymentWayID>
        <PaymentWayName>现金</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CASH</PrepayType>
        <SubPaySystem>1</SubPaySystem>
        <PaySystemName>现金类支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <PromotionText />
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>0</CreditCardType>
        <CreditCardBankID>0</CreditCardBankID>
        <PaymentWayID>Remittance</PaymentWayID>
        <PaymentWayName>转账汇款</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CASH</PrepayType>
        <SubPaySystem>1</SubPaySystem>
        <PaySystemName>现金类支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        </PaymentWayItems>
        </PaymentCatalogItem>
        <PaymentCatalogItem>
        <PaymentCatalogID>1</PaymentCatalogID>
        <CatalogName>信用卡</CatalogName>
        <CatalogCode>CreditCard</CatalogCode>
        <TipsToPay />
        <CatalogDescription />
        <PaymentWayItems>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>8</CreditCardType>
        <CreditCardBankID>8</CreditCardBankID>
        <PaymentWayID>CC_AmericanExpress</PaymentWayID>
        <PaymentWayName>运通(AMEX)</PaymentWayName>
        <PaymentWayGlobalName>American Express Card</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>510</CreditCardBankID>
        <PaymentWayID>CC_BANKOFDL</PaymentWayID>
        <PaymentWayName>大连银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>大连银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>549</CreditCardBankID>
        <PaymentWayID>CC_BEEB</PaymentWayID>
        <PaymentWayName>鄞州银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>鄞州银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>27</CreditCardType>
        <CreditCardBankID>27</CreditCardBankID>
        <PaymentWayID>CC_BJBANK</PaymentWayID>
        <PaymentWayName>北京银行</PaymentWayName>
        <PaymentWayGlobalName>Bank of Beijing</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>502</CreditCardBankID>
        <PaymentWayID>CC_BJRCB</PaymentWayID>
        <PaymentWayName>北京农商银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>北京农商银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>526</CreditCardBankID>
        <PaymentWayID>CC_BOJ</PaymentWayID>
        <PaymentWayName>锦州银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>锦州银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>530</CreditCardBankID>
        <PaymentWayID>CC_BOL</PaymentWayID>
        <PaymentWayName>兰州银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption>兰州银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>533</CreditCardBankID>
        <PaymentWayID>CC_BOQ</PaymentWayID>
        <PaymentWayName>青海银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>青海银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>503</CreditCardBankID>
        <PaymentWayID>CC_BSB</PaymentWayID>
        <PaymentWayName>包商银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>包商银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>508</CreditCardBankID>
        <PaymentWayID>CC_CDB</PaymentWayID>
        <PaymentWayName>承德银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>承德银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>504</CreditCardBankID>
        <PaymentWayID>CC_CDRCB</PaymentWayID>
        <PaymentWayName>成都农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>成都农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>15</CreditCardType>
        <CreditCardBankID>15</CreditCardBankID>
        <PaymentWayID>CC_CEBBANK</PaymentWayID>
        <PaymentWayName>光大银行</PaymentWayName>
        <PaymentWayGlobalName>China Everybright Bank</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <PromotionText />
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>20</CreditCardType>
        <CreditCardBankID>20</CreditCardBankID>
        <PaymentWayID>CC_CIB</PaymentWayID>
        <PaymentWayName>业兴银行</PaymentWayName>
        <PaymentWayGlobalName>Industrial Bank Co.ltd</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>17</CreditCardType>
        <CreditCardBankID>17</CreditCardBankID>
        <PaymentWayID>CC_CITIC</PaymentWayID>
        <PaymentWayName>中信银行</PaymentWayName>
        <PaymentWayGlobalName>China CITIC Bank</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>572</CreditCardBankID>
        <PaymentWayID>CC_CITYBANK</PaymentWayID>
        <PaymentWayName>花旗银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>558</CreditCardBankID>
        <PaymentWayID>CC_CMB2</PaymentWayID>
        <PaymentWayName>招商银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <PromotionText />
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>561</CreditCardBankID>
        <PaymentWayID>CC_CMBC2</PaymentWayID>
        <PaymentWayName>民生银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <PromotionText />
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>3</CreditCardType>
        <CreditCardBankID>3</CreditCardBankID>
        <PaymentWayID>CC_COMM</PaymentWayID>
        <PaymentWayName>交通银行</PaymentWayName>
        <PaymentWayGlobalName>China Communication Bank</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>509</CreditCardBankID>
        <PaymentWayID>CC_CQCB</PaymentWayID>
        <PaymentWayName>重庆银行 </PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>重庆银行 </Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>505</CreditCardBankID>
        <PaymentWayID>CC_CQRCB</PaymentWayID>
        <PaymentWayName>重庆农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>重庆农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>507</CreditCardBankID>
        <PaymentWayID>CC_CSCB</PaymentWayID>
        <PaymentWayName>长沙银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>长沙银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>506</CreditCardBankID>
        <PaymentWayID>CC_CSRCB</PaymentWayID>
        <PaymentWayName>常熟农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>常熟农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>550</CreditCardBankID>
        <PaymentWayID>CC_CZCB</PaymentWayID>
        <PaymentWayName>浙江稠州商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>浙江稠州商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>9</CreditCardType>
        <CreditCardBankID>9</CreditCardBankID>
        <PaymentWayID>CC_DinersClub</PaymentWayID>
        <PaymentWayName>大来(Diners Club)</PaymentWayName>
        <PaymentWayGlobalName>Diners Card</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>511</CreditCardBankID>
        <PaymentWayID>CC_DYCCB</PaymentWayID>
        <PaymentWayName>东营银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>东营银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>514</CreditCardBankID>
        <PaymentWayID>CC_FDB</PaymentWayID>
        <PaymentWayName>富滇银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>富滇银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>513</CreditCardBankID>
        <PaymentWayID>CC_FJNX</PaymentWayID>
        <PaymentWayName>福建省农村信用社</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>福建省农村信用社</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>13</CreditCardType>
        <CreditCardBankID>13</CreditCardBankID>
        <PaymentWayID>CC_GDB</PaymentWayID>
        <PaymentWayName>广发银行</PaymentWayName>
        <PaymentWayGlobalName>China Guangfa Bank</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <PromotionText />
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>516</CreditCardBankID>
        <PaymentWayID>CC_GRCB</PaymentWayID>
        <PaymentWayName>广州农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>广州农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>518</CreditCardBankID>
        <PaymentWayID>CC_GYCCB</PaymentWayID>
        <PaymentWayName>贵阳银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>贵阳银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>515</CreditCardBankID>
        <PaymentWayID>CC_GZCB</PaymentWayID>
        <PaymentWayName>广州银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>广州银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>517</CreditCardBankID>
        <PaymentWayID>CC_GZCCB</PaymentWayID>
        <PaymentWayName>赣州银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>赣州银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>520</CreditCardBankID>
        <PaymentWayID>CC_HEB</PaymentWayID>
        <PaymentWayName>河北银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>河北银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>26</CreditCardType>
        <CreditCardBankID>26</CreditCardBankID>
        <PaymentWayID>CC_HKBEA</PaymentWayID>
        <PaymentWayName>东亚银行</PaymentWayName>
        <PaymentWayGlobalName>Bank of East Asia</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>523</CreditCardBankID>
        <PaymentWayID>CC_HNNXS</PaymentWayID>
        <PaymentWayName>湖南省农村信用社联合社</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>湖南省农村信用社联合社</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>522</CreditCardBankID>
        <PaymentWayID>CC_HRBCB</PaymentWayID>
        <PaymentWayName>哈尔滨银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>哈尔滨银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>521</CreditCardBankID>
        <PaymentWayID>CC_HSBank</PaymentWayID>
        <PaymentWayName>徽商银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>徽商银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>519</CreditCardBankID>
        <PaymentWayID>CC_HZBANK</PaymentWayID>
        <PaymentWayName>杭州银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>杭州银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>554</CreditCardBankID>
        <PaymentWayID>CC_ICBC2</PaymentWayID>
        <PaymentWayName>工商银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <PromotionText />
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>10</CreditCardType>
        <CreditCardBankID>10</CreditCardBankID>
        <PaymentWayID>CC_JCB</PaymentWayID>
        <PaymentWayName>JCB</PaymentWayName>
        <PaymentWayGlobalName>JCB Card</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>528</CreditCardBankID>
        <PaymentWayID>CC_JJCCB</PaymentWayID>
        <PaymentWayName>九江银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>九江银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>527</CreditCardBankID>
        <PaymentWayID>CC_JNCCB</PaymentWayID>
        <PaymentWayName>金华银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>金华银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>524</CreditCardBankID>
        <PaymentWayID>CC_JPRCU</PaymentWayID>
        <PaymentWayName>江苏省农村信用社联合社</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>江苏省农村信用社联合社</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>28</CreditCardType>
        <CreditCardBankID>28</CreditCardBankID>
        <PaymentWayID>CC_JSB</PaymentWayID>
        <PaymentWayName>江苏银行</PaymentWayName>
        <PaymentWayGlobalName>Jiangsu Bank</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>525</CreditCardBankID>
        <PaymentWayID>CC_JYRCB</PaymentWayID>
        <PaymentWayName>江阴农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>江阴农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>529</CreditCardBankID>
        <PaymentWayID>CC_LJBC</PaymentWayID>
        <PaymentWayName>龙江银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>龙江银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>6</CreditCardType>
        <CreditCardBankID>6</CreditCardBankID>
        <PaymentWayID>CC_MasterCard</PaymentWayID>
        <PaymentWayName>万事达(Master)</PaymentWayName>
        <PaymentWayGlobalName>Master Card</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>551</CreditCardBankID>
        <PaymentWayID>CC_MTB</PaymentWayID>
        <PaymentWayName>浙江民泰商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>浙江民泰商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>25</CreditCardType>
        <CreditCardBankID>25</CreditCardBankID>
        <PaymentWayID>CC_NBBANK</PaymentWayID>
        <PaymentWayName>宁波银行</PaymentWayName>
        <PaymentWayGlobalName>Bank of Ningbo</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>531</CreditCardBankID>
        <PaymentWayID>CC_NCCB</PaymentWayID>
        <PaymentWayName>南昌银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>南昌银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>532</CreditCardBankID>
        <PaymentWayID>CC_NJCB</PaymentWayID>
        <PaymentWayName>南京银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>南京银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>512</CreditCardBankID>
        <PaymentWayID>CC_ORDOSBANK</PaymentWayID>
        <PaymentWayName>鄂尔多斯银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>鄂尔多斯银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>501</CreditCardBankID>
        <PaymentWayID>CC_PSBC</PaymentWayID>
        <PaymentWayName>邮政储蓄银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>邮政储蓄银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>535</CreditCardBankID>
        <PaymentWayID>CC_QBCCB</PaymentWayID>
        <PaymentWayName>青岛银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>青岛银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>534</CreditCardBankID>
        <PaymentWayID>CC_QLBC</PaymentWayID>
        <PaymentWayName>齐鲁银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>齐鲁银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>566</CreditCardBankID>
        <PaymentWayID>CC_SDB2</PaymentWayID>
        <PaymentWayName>深发银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <PromotionText />
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>538</CreditCardBankID>
        <PaymentWayID>CC_SDEB</PaymentWayID>
        <PaymentWayName>顺德农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>顺德农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>21</CreditCardType>
        <CreditCardBankID>21</CreditCardBankID>
        <PaymentWayID>CC_SHBANK</PaymentWayID>
        <PaymentWayName>上海银行</PaymentWayName>
        <PaymentWayGlobalName>Bank of Shanghai</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <PromotionText />
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>566</CreditCardBankID>
        <PaymentWayID>CC_SPABANK2</PaymentWayID>
        <PaymentWayName>平安(深发)银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <PromotionText />
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>18</CreditCardType>
        <CreditCardBankID>18</CreditCardBankID>
        <PaymentWayID>CC_SPDB</PaymentWayID>
        <PaymentWayName>浦发银行</PaymentWayName>
        <PaymentWayGlobalName>Shanghai Pudong Development Bank</PaymentWayGlobalName>
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>537</CreditCardBankID>
        <PaymentWayID>CC_SRB</PaymentWayID>
        <PaymentWayName>上饶银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>上饶银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>536</CreditCardBankID>
        <PaymentWayID>CC_SRCB</PaymentWayID>
        <PaymentWayName>上海农商银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>上海农商银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>540</CreditCardBankID>
        <PaymentWayID>CC_TZB</PaymentWayID>
        <PaymentWayName>台州银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>台州银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>546</CreditCardBankID>
        <PaymentWayID>CC_UCCB</PaymentWayID>
        <PaymentWayName>乌鲁木齐市商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>乌鲁木齐市商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>541</CreditCardBankID>
        <PaymentWayID>CC_WFCCB</PaymentWayID>
        <PaymentWayName>潍坊银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>潍坊银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>542</CreditCardBankID>
        <PaymentWayID>CC_WHCCB</PaymentWayID>
        <PaymentWayName>威海市商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>威海市商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>543</CreditCardBankID>
        <PaymentWayID>CC_WJRCB</PaymentWayID>
        <PaymentWayName>吴江农商银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>吴江农商银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>544</CreditCardBankID>
        <PaymentWayID>CC_WRCB</PaymentWayID>
        <PaymentWayName>无锡农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>无锡农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>545</CreditCardBankID>
        <PaymentWayID>CC_WZCB</PaymentWayID>
        <PaymentWayName>温州银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>温州银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>547</CreditCardBankID>
        <PaymentWayID>CC_YCCB</PaymentWayID>
        <PaymentWayName>宜昌市商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>宜昌市商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>548</CreditCardBankID>
        <PaymentWayID>CC_YCCCB</PaymentWayID>
        <PaymentWayName>银川市商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>银川市商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>539</CreditCardBankID>
        <PaymentWayID>CC_YDRCB</PaymentWayID>
        <PaymentWayName>山西尧都农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>山西尧都农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>552</CreditCardBankID>
        <PaymentWayID>CC_ZJTLCB</PaymentWayID>
        <PaymentWayName>浙江泰隆商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>浙江泰隆商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>500</CreditCardType>
        <CreditCardBankID>553</CreditCardBankID>
        <PaymentWayID>CC_BOC2</PaymentWayID>
        <PaymentWayName>中国银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <PromotionText />
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        <PaymentWayID_Source>CC_BOC</PaymentWayID_Source>
        </PaymentWayItem>
        </PaymentWayItems>
        </PaymentCatalogItem>
        <PaymentCatalogItem>
        <PaymentCatalogID>6</PaymentCatalogID>
        <CatalogName>信用卡担保</CatalogName>
        <CatalogCode>CCGuarantee</CatalogCode>
        <TipsToPay />
        <CatalogDescription />
        <PaymentWayItems>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>8</CreditCardType>
        <CreditCardBankID>8</CreditCardBankID>
        <PaymentWayID>CCG_AmericanExpress</PaymentWayID>
        <PaymentWayName>运通(AMEX)</PaymentWayName>
        <PaymentWayGlobalName>American Express Card</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>27</CreditCardType>
        <CreditCardBankID>27</CreditCardBankID>
        <PaymentWayID>CCG_BJBANK</PaymentWayID>
        <PaymentWayName>北京银行</PaymentWayName>
        <PaymentWayGlobalName>Bank of Beijing</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1</CreditCardType>
        <CreditCardBankID>1</CreditCardBankID>
        <PaymentWayID>CCG_BOC</PaymentWayID>
        <PaymentWayName>中国银行</PaymentWayName>
        <PaymentWayGlobalName>Bank of China</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>5</CreditCardType>
        <CreditCardBankID>5</CreditCardBankID>
        <PaymentWayID>CCG_CCB</PaymentWayID>
        <PaymentWayName>中国建设银行</PaymentWayName>
        <PaymentWayGlobalName>China Construction Bank</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>15</CreditCardType>
        <CreditCardBankID>15</CreditCardBankID>
        <PaymentWayID>CCG_CEBBANK</PaymentWayID>
        <PaymentWayName>光大银行</PaymentWayName>
        <PaymentWayGlobalName>China Everybright Bank</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>20</CreditCardType>
        <CreditCardBankID>20</CreditCardBankID>
        <PaymentWayID>CCG_CIB</PaymentWayID>
        <PaymentWayName>业兴银行</PaymentWayName>
        <PaymentWayGlobalName>Industrial Bank Co.ltd</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>17</CreditCardType>
        <CreditCardBankID>17</CreditCardBankID>
        <PaymentWayID>CCG_CITIC</PaymentWayID>
        <PaymentWayName>中信银行</PaymentWayName>
        <PaymentWayGlobalName>China CITIC Bank</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>11</CreditCardType>
        <CreditCardBankID>11</CreditCardBankID>
        <PaymentWayID>CCG_CMB</PaymentWayID>
        <PaymentWayName>招商银行</PaymentWayName>
        <PaymentWayGlobalName>China Merchants Bank</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>16</CreditCardType>
        <CreditCardBankID>16</CreditCardBankID>
        <PaymentWayID>CCG_CMBC</PaymentWayID>
        <PaymentWayName>民生银行</PaymentWayName>
        <PaymentWayGlobalName>China Minsheng Banking</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>3</CreditCardType>
        <CreditCardBankID>3</CreditCardBankID>
        <PaymentWayID>CCG_COMM</PaymentWayID>
        <PaymentWayName>交通银行</PaymentWayName>
        <PaymentWayGlobalName>China Communication Bank</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>9</CreditCardType>
        <CreditCardBankID>9</CreditCardBankID>
        <PaymentWayID>CCG_DinersClub</PaymentWayID>
        <PaymentWayName>大来(Diners Club)</PaymentWayName>
        <PaymentWayGlobalName>Diners Card</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>13</CreditCardType>
        <CreditCardBankID>13</CreditCardBankID>
        <PaymentWayID>CCG_GDB</PaymentWayID>
        <PaymentWayName>广发银行</PaymentWayName>
        <PaymentWayGlobalName>China Guangfa Bank</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>26</CreditCardType>
        <CreditCardBankID>26</CreditCardBankID>
        <PaymentWayID>CCG_HKBEA</PaymentWayID>
        <PaymentWayName>东亚银行</PaymentWayName>
        <PaymentWayGlobalName>Bank of East Asia</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>24</CreditCardType>
        <CreditCardBankID>24</CreditCardBankID>
        <PaymentWayID>CCG_HXB</PaymentWayID>
        <PaymentWayName>华夏银行</PaymentWayName>
        <PaymentWayGlobalName>HuaXia Bank</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>2</CreditCardType>
        <CreditCardBankID>2</CreditCardBankID>
        <PaymentWayID>CCG_ICBC</PaymentWayID>
        <PaymentWayName>工商银行</PaymentWayName>
        <PaymentWayGlobalName>Industry &amp;amp; Commercial Bank of China</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>10</CreditCardType>
        <CreditCardBankID>10</CreditCardBankID>
        <PaymentWayID>CCG_JCB</PaymentWayID>
        <PaymentWayName>JCB</PaymentWayName>
        <PaymentWayGlobalName>JCB Card</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>28</CreditCardType>
        <CreditCardBankID>28</CreditCardBankID>
        <PaymentWayID>CCG_JSB</PaymentWayID>
        <PaymentWayName>江苏银行</PaymentWayName>
        <PaymentWayGlobalName>Jiangsu Bank</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>6</CreditCardType>
        <CreditCardBankID>6</CreditCardBankID>
        <PaymentWayID>CCG_MasterCard</PaymentWayID>
        <PaymentWayName>万事达(Master)</PaymentWayName>
        <PaymentWayGlobalName>Master Card</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>25</CreditCardType>
        <CreditCardBankID>25</CreditCardBankID>
        <PaymentWayID>CCG_NBBANK</PaymentWayID>
        <PaymentWayName>宁波银行</PaymentWayName>
        <PaymentWayGlobalName>Bank of Ningbo</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>22</CreditCardType>
        <CreditCardBankID>22</CreditCardBankID>
        <PaymentWayID>CCG_SDB</PaymentWayID>
        <PaymentWayName>深发银行</PaymentWayName>
        <PaymentWayGlobalName>Shenzhen Development Bank</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>21</CreditCardType>
        <CreditCardBankID>21</CreditCardBankID>
        <PaymentWayID>CCG_SHBANK</PaymentWayID>
        <PaymentWayName>上海银行</PaymentWayName>
        <PaymentWayGlobalName>Bank of Shanghai</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>22</CreditCardType>
        <CreditCardBankID>22</CreditCardBankID>
        <PaymentWayID>CCG_SPABANK</PaymentWayID>
        <PaymentWayName>平安银行</PaymentWayName>
        <PaymentWayGlobalName>Ping An Bank</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>18</CreditCardType>
        <CreditCardBankID>18</CreditCardBankID>
        <PaymentWayID>CCG_SPDB</PaymentWayID>
        <PaymentWayName>浦发银行</PaymentWayName>
        <PaymentWayGlobalName>Shanghai Pudong Development Bank</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>7</CreditCardType>
        <CreditCardBankID>7</CreditCardBankID>
        <PaymentWayID>CCG_VISA</PaymentWayID>
        <PaymentWayName>威士(VISA)</PaymentWayName>
        <PaymentWayGlobalName>Visa Card</PaymentWayGlobalName>
        <PrepayType>CGPAY</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        </PaymentWayItems>
        </PaymentCatalogItem>
        <PaymentCatalogItem>
        <PaymentCatalogID>7</PaymentCatalogID>
        <CatalogName>积分担保</CatalogName>
        <CatalogCode>CreditsGuarantee</CatalogCode>
        <TipsToPay />
        <CatalogDescription />
        <PaymentWayItems>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>0</CreditCardType>
        <CreditCardBankID>0</CreditCardBankID>
        <PaymentWayID>CreditsGuarantee</PaymentWayID>
        <PaymentWayName>积分</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>POINT</PrepayType>
        <SubPaySystem>8</SubPaySystem>
        <PaySystemName>积分担保</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        </PaymentWayItems>
        </PaymentCatalogItem>
        <PaymentCatalogItem>
        <PaymentCatalogID>16</PaymentCatalogID>
        <CatalogName>储蓄卡快捷</CatalogName>
        <CatalogCode>DepositCard</CatalogCode>
        <TipsToPay />
        <CatalogDescription>储蓄卡快捷</CatalogDescription>
        <PaymentWayItems>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1128</CreditCardBankID>
        <PaymentWayID>DQ_ABC</PaymentWayID>
        <PaymentWayName>农业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <PromotionText>支付满100减11元</PromotionText>
        <Descrption>农业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1003</CreditCardBankID>
        <PaymentWayID>DQ_ASRBS</PaymentWayID>
        <PaymentWayName>安顺市商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <PromotionText>支付满100减11元</PromotionText>
        <Descrption>安顺市商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1006</CreditCardBankID>
        <PaymentWayID>DQ_BDB</PaymentWayID>
        <PaymentWayName>保定银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <PromotionText>支付满100减11元</PromotionText>
        <Descrption>保定银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1141</CreditCardBankID>
        <PaymentWayID>DQ_BJBANK</PaymentWayID>
        <PaymentWayName>北京银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>北京银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1009</CreditCardBankID>
        <PaymentWayID>DQ_BOCD</PaymentWayID>
        <PaymentWayName>成都银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <PromotionText>支付满100减11元</PromotionText>
        <Descrption>成都银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1064</CreditCardBankID>
        <PaymentWayID>DQ_BOIMC</PaymentWayID>
        <PaymentWayName>内蒙古银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>内蒙古银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1062</CreditCardBankID>
        <PaymentWayID>DQ_BOL</PaymentWayID>
        <PaymentWayName>兰州银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>兰州银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1002</CreditCardBankID>
        <PaymentWayID>DQ_CBNB</PaymentWayID>
        <PaymentWayName>渤海银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>渤海银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1130</CreditCardBankID>
        <PaymentWayID>DQ_CCB</PaymentWayID>
        <PaymentWayName>建设银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>建设银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1044</CreditCardBankID>
        <PaymentWayID>DQ_JXNXS</PaymentWayID>
        <PaymentWayName>江西农村信用联合社</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>江西农村信用联合社</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1055</CreditCardBankID>
        <PaymentWayID>DQ_KLB</PaymentWayID>
        <PaymentWayName>昆仑银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>昆仑银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1056</CreditCardBankID>
        <PaymentWayID>DQ_LJBC</PaymentWayID>
        <PaymentWayName>龙江银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>龙江银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1058</CreditCardBankID>
        <PaymentWayID>DQ_LSCCB</PaymentWayID>
        <PaymentWayName>乐山市商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>乐山市商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1069</CreditCardBankID>
        <PaymentWayID>DQ_NJCB</PaymentWayID>
        <PaymentWayName>南京银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>南京银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1065</CreditCardBankID>
        <PaymentWayID>DQ_NMGRCB</PaymentWayID>
        <PaymentWayName>内蒙古农村信用社</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>内蒙古农村信用社</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1071</CreditCardBankID>
        <PaymentWayID>DQ_PDSCB</PaymentWayID>
        <PaymentWayName>平顶山银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>平顶山银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1001</CreditCardBankID>
        <PaymentWayID>DQ_PSBC</PaymentWayID>
        <PaymentWayName>邮政储蓄银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>邮政储蓄银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1078</CreditCardBankID>
        <PaymentWayID>DQ_QBCCB</PaymentWayID>
        <PaymentWayName>青岛银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>青岛银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1077</CreditCardBankID>
        <PaymentWayID>DQ_QHRCB</PaymentWayID>
        <PaymentWayName>青海省农村信用社</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>青海省农村信用社</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1073</CreditCardBankID>
        <PaymentWayID>DQ_QLBC</PaymentWayID>
        <PaymentWayName>齐鲁银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>齐鲁银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1088</CreditCardBankID>
        <PaymentWayID>DQ_SCRCU</PaymentWayID>
        <PaymentWayName>四川省农村信用合作社</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>四川省农村信用合作社</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1136</CreditCardBankID>
        <PaymentWayID>DQ_SDB</PaymentWayID>
        <PaymentWayName>深圳发展银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>深圳发展银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1087</CreditCardBankID>
        <PaymentWayID>DQ_SDEB</PaymentWayID>
        <PaymentWayName>顺德农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>顺德农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1125</CreditCardBankID>
        <PaymentWayID>DQ_SHB</PaymentWayID>
        <PaymentWayName>新韩银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>新韩银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1142</CreditCardBankID>
        <PaymentWayID>DQ_SHBANK</PaymentWayID>
        <PaymentWayName>上海银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>上海银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1080</CreditCardBankID>
        <PaymentWayID>DQ_SMXB</PaymentWayID>
        <PaymentWayName>三门峡银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>三门峡银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1140</CreditCardBankID>
        <PaymentWayID>DQ_SPABANK</PaymentWayID>
        <PaymentWayName>平安银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>平安银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1139</CreditCardBankID>
        <PaymentWayID>DQ_SPDB</PaymentWayID>
        <PaymentWayName>浦发银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>浦发银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1079</CreditCardBankID>
        <PaymentWayID>DQ_SRCB</PaymentWayID>
        <PaymentWayName>上海农商银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>上海农商银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1085</CreditCardBankID>
        <PaymentWayID>DQ_SZB</PaymentWayID>
        <PaymentWayName>苏州银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>苏州银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1084</CreditCardBankID>
        <PaymentWayID>DQ_SZRCB</PaymentWayID>
        <PaymentWayName>深圳农商银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>深圳农商银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1091</CreditCardBankID>
        <PaymentWayID>DQ_TACCB</PaymentWayID>
        <PaymentWayName>泰安市商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>泰安市商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1093</CreditCardBankID>
        <PaymentWayID>DQ_TSBANK</PaymentWayID>
        <PaymentWayName>唐山市商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>唐山市商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1097</CreditCardBankID>
        <PaymentWayID>DQ_WHCCB</PaymentWayID>
        <PaymentWayName>威海市商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>威海市商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1100</CreditCardBankID>
        <PaymentWayID>DQ_WRCB</PaymentWayID>
        <PaymentWayName>无锡农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>无锡农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1101</CreditCardBankID>
        <PaymentWayID>DQ_WZCB</PaymentWayID>
        <PaymentWayName>温州银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>温州银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1103</CreditCardBankID>
        <PaymentWayID>DQ_XMCCB</PaymentWayID>
        <PaymentWayName>厦门银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>厦门银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1116</CreditCardBankID>
        <PaymentWayID>DQ_ZRCB</PaymentWayID>
        <PaymentWayName>张家港农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>张家港农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1012</CreditCardBankID>
        <PaymentWayID>DQ_CDB</PaymentWayID>
        <PaymentWayName>承德银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>承德银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1133</CreditCardBankID>
        <PaymentWayID>DQ_CEBBANK</PaymentWayID>
        <PaymentWayName>光大银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>光大银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1070</CreditCardBankID>
        <PaymentWayID>DQ_CGNB</PaymentWayID>
        <PaymentWayName>南充市商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>南充市商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1138</CreditCardBankID>
        <PaymentWayID>DQ_CIB</PaymentWayID>
        <PaymentWayName>兴业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>兴业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1132</CreditCardBankID>
        <PaymentWayID>DQ_CITIC</PaymentWayID>
        <PaymentWayName>中信银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>中信银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1137</CreditCardBankID>
        <PaymentWayID>DQ_CMB</PaymentWayID>
        <PaymentWayName>招商银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <PromotionText>支付满100减11元</PromotionText>
        <Descrption>招商银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1135</CreditCardBankID>
        <PaymentWayID>DQ_CMBC</PaymentWayID>
        <PaymentWayName>民生银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>民生银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1131</CreditCardBankID>
        <PaymentWayID>DQ_COMM</PaymentWayID>
        <PaymentWayName>交通银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <PromotionText>支付满100减11元</PromotionText>
        <Descrption>交通银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1010</CreditCardBankID>
        <PaymentWayID>DQ_CQRCB</PaymentWayID>
        <PaymentWayName>重庆农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>重庆农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1015</CreditCardBankID>
        <PaymentWayID>DQ_DeYangCCB</PaymentWayID>
        <PaymentWayName>德阳银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>德阳银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1016</CreditCardBankID>
        <PaymentWayID>DQ_DRCB</PaymentWayID>
        <PaymentWayName>东莞农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>东莞农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1025</CreditCardBankID>
        <PaymentWayID>DQ_GRCB</PaymentWayID>
        <PaymentWayName>广州农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>广州农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1022</CreditCardBankID>
        <PaymentWayID>DQ_GXRCB</PaymentWayID>
        <PaymentWayName>广西农村信用社</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>广西农村信用社</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1023</CreditCardBankID>
        <PaymentWayID>DQ_GZCB</PaymentWayID>
        <PaymentWayName>广州银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>广州银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1039</CreditCardBankID>
        <PaymentWayID>DQ_HBB</PaymentWayID>
        <PaymentWayName>湖北银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>湖北银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1038</CreditCardBankID>
        <PaymentWayID>DQ_HBXH</PaymentWayID>
        <PaymentWayName>湖北省农村信用社联合社</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>湖北省农村信用社联合社</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1041</CreditCardBankID>
        <PaymentWayID>DQ_HDCB</PaymentWayID>
        <PaymentWayName>邯郸银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>邯郸银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1030</CreditCardBankID>
        <PaymentWayID>DQ_HEB</PaymentWayID>
        <PaymentWayName>河北银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>河北银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1031</CreditCardBankID>
        <PaymentWayID>DQ_HEBNX</PaymentWayID>
        <PaymentWayName>河北省农村信用社</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>河北省农村信用社</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1037</CreditCardBankID>
        <PaymentWayID>DQ_HNNXS</PaymentWayID>
        <PaymentWayName>湖南省农村信用社联合社</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>湖南省农村信用社联合社</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1035</CreditCardBankID>
        <PaymentWayID>DQ_HRBCB</PaymentWayID>
        <PaymentWayName>哈尔滨银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>哈尔滨银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1134</CreditCardBankID>
        <PaymentWayID>DQ_HXB</PaymentWayID>
        <PaymentWayName>华夏银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>华夏银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1127</CreditCardBankID>
        <PaymentWayID>DQ_ICBC</PaymentWayID>
        <PaymentWayName>工商银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>工商银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1052</CreditCardBankID>
        <PaymentWayID>DQ_JJCCB</PaymentWayID>
        <PaymentWayName>九江银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>九江银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1047</CreditCardBankID>
        <PaymentWayID>DQ_JNRCB</PaymentWayID>
        <PaymentWayName>江南农村商业银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>江南农村商业银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1143</CreditCardBankID>
        <PaymentWayID>DQ_JSB</PaymentWayID>
        <PaymentWayName>江苏银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>江苏银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1043</CreditCardBankID>
        <PaymentWayID>DQ_JXB</PaymentWayID>
        <PaymentWayName>晋城银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>晋城银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        <PaymentWayItem>
        <IsSupportPreAuth>false</IsSupportPreAuth>
        <CreditCardType>1000</CreditCardType>
        <CreditCardBankID>1042</CreditCardBankID>
        <PaymentWayID>DQ_JXCCB</PaymentWayID>
        <PaymentWayName>嘉兴银行</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>CCARD</PrepayType>
        <SubPaySystem>2</SubPaySystem>
        <PaySystemName>银行卡支付</PaySystemName>
        <ActionMode>Auto</ActionMode>
        <Descrption>嘉兴银行</Descrption>
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>true</IsSupportRealTime>
        </PaymentWayItem>
        </PaymentWayItems>
        </PaymentCatalogItem>
        <PaymentCatalogItem>
        <PaymentCatalogID>22</PaymentCatalogID>
        <CatalogName>其他担保</CatalogName>
        <CatalogCode>OtherGuarantee</CatalogCode>
        <TipsToPay />
        <CatalogDescription />
        <PaymentWayItems>
        <PaymentWayItem>
        <IsSupportPreAuth>true</IsSupportPreAuth>
        <CreditCardType>0</CreditCardType>
        <CreditCardBankID>0</CreditCardBankID>
        <PaymentWayID>OGP_Alipay</PaymentWayID>
        <PaymentWayName>支付宝</PaymentWayName>
        <PaymentWayGlobalName />
        <PrepayType>ALPAY</PrepayType>
        <SubPaySystem>3</SubPaySystem>
        <PaySystemName>第三方支付</PaySystemName>
        <ActionMode>Manual</ActionMode>
        <Descrption />
        <IsUsedCardAvailable>true</IsUsedCardAvailable>
        <IsSupportRealTime>false</IsSupportRealTime>
        </PaymentWayItem>
        </PaymentWayItems>
        </PaymentCatalogItem>
        </PaymentCatalogs>
        </InqurieMerchantPayWayResponse>
        </Response>
      </RequestResult>
    </RequestResponse>
  </soap:Body>
</soap:Envelope>";


            }

            return @"<?xml version='1.0'?><Response><Header ServerIP='10.2.254.17' Culture='cn' ShouldRecordPerformanceTime='false' UserID='410471' RequestID='8bec1642-b0fb-4cb1-9784-6ae195aa2533' ResultCode='Success' ResultNo='0' ResultMsg='成功' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fat18' /><InqurieMerchantPayWayResponse><MerchantID>200124</MerchantID><MerchantName>讨盘缠</MerchantName><ForeignCardCharge>3.00</ForeignCardCharge><EnabledDCC>false</EnabledDCC><UserInformation><IsNeedCheckPhoneNo>false</IsNeedCheckPhoneNo><IsNeedVerifyUserPhoneForCreditCard>false</IsNeedVerifyUserPhoneForCreditCard></UserInformation><IsWalletAvailable>true</IsWalletAvailable><TMPayItems><EnableTMPayType>3</EnableTMPayType></TMPayItems><PaymentCatalogs><PaymentCatalogItem><PaymentCatalogID>2</PaymentCatalogID><CatalogName>网上支付</CatalogName><CatalogCode>EBank</CatalogCode><TipsToPay /><CatalogDescription>&lt;p class='paycredit_info2'&gt; 1.订单提交成功后会自动跳转至银行支付页面,请及时支付。&lt;/p&gt; &lt;p class='paycredit_info2'&gt; 2.支付成功后我司会尽快安排出票,最终出票情况以我司确认为准。&lt;/p&gt; &lt;p class='paycredit_info2'&gt; 3.提交后30分钟仍未付款,我司会取消订单。&lt;/p&gt;</CatalogDescription><PaymentWayItems><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>Alipay</PaymentWayID><PaymentWayName>支付宝</PaymentWayName><PaymentWayGlobalName /><PrepayType>ALPAY</PrepayType><SubPaySystem>3</SubPaySystem><PaySystemName>第三方支付</PaySystemName><ActionMode>Manual</ActionMode><Descrption>&lt;p class='paycredit_info'&gt; 注意事项：1.订单提交成功后会自动跳转至支付宝网站,请及时支付。&lt;/p&gt; &lt;p class='paycredit_info2'&gt; 2.支付成功后我司会尽快安排出票,最终出票情况以我司确认为准。&lt;/p&gt; &lt;p class='paycredit_info2'&gt; 3.提交后30分钟仍未付款,我司会取消订单。&lt;/p&gt;</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>EB_ICBC_Alipay</PaymentWayID><PaymentWayName>工行网银</PaymentWayName><PaymentWayGlobalName /><PrepayType>ALPAY</PrepayType><SubPaySystem>3</SubPaySystem><PaySystemName>第三方支付</PaySystemName><ActionMode>Manual</ActionMode><PromotionText /><Descrption>&lt;p class='paycredit_info'&gt;注意事项：柜面注册密码客户：单笔和每日累计消费限额为300元；口令卡客户：未开通短信认证,单笔消费限额500元,每日累计消费限额1000元&lt;br /&gt;&lt;span style='padding-left:60px;'&gt;已开通短信认证,单笔消费限额2000元,每日累计消费限额5000元；U盾客户单笔和每日累计消费限额为100万元。&lt;/span&gt;&lt;/p&gt;</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>EB_MobileAlipay</PaymentWayID><PaymentWayName>移动版支付宝</PaymentWayName><PaymentWayGlobalName /><PrepayType>MAPAY</PrepayType><SubPaySystem>3</SubPaySystem><PaySystemName>第三方支付</PaySystemName><ActionMode>Auto</ActionMode><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>EB_MobileUnionPay</PaymentWayID><PaymentWayName>移动版银联在线支付</PaymentWayName><PaymentWayGlobalName /><PrepayType>MUPAY</PrepayType><SubPaySystem>3</SubPaySystem><PaySystemName>第三方支付</PaySystemName><ActionMode>Auto</ActionMode><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>EB_UnionPay</PaymentWayID><PaymentWayName>银联在线支付</PaymentWayName><PaymentWayGlobalName /><PrepayType>UNPAY</PrepayType><SubPaySystem>3</SubPaySystem><PaySystemName>第三方支付</PaySystemName><ActionMode>Auto</ActionMode><Descrption /><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>WechatScanCode</PaymentWayID><PaymentWayName>微信支付 </PaymentWayName><PaymentWayGlobalName /><PrepayType>WSCAN</PrepayType><SubPaySystem>3</SubPaySystem><PaySystemName>第三方支付</PaySystemName><ActionMode>Auto</ActionMode><Descrption>微信支付 (公众账号)</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>EB_BOC</PaymentWayID><PaymentWayName>中国银行</PaymentWayName><PaymentWayGlobalName /><PrepayType>BCPAY</PrepayType><SubPaySystem>3</SubPaySystem><PaySystemName>第三方支付</PaySystemName><ActionMode>Manual</ActionMode><PromotionText /><Descrption>&lt;p class='paycredit_info'&gt;注意事项：支持借记卡注册用户,单笔消费限额10,000元,当日累计消费限额50,000元。&lt;/p&gt;</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>EB_CMB</PaymentWayID><PaymentWayName>招商银行</PaymentWayName><PaymentWayGlobalName /><PrepayType>CMPAY</PrepayType><SubPaySystem>3</SubPaySystem><PaySystemName>第三方支付</PaySystemName><ActionMode>Manual</ActionMode><PromotionText /><Descrption>&lt;p class='paycredit_info'&gt;注意事项：支持借记卡支付,其中大众版网银用户单笔消费限额为5,000元,每日累计消费限额为10,000元,专业版用户无额度限制。&lt;/p&gt;</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem></PaymentWayItems></PaymentCatalogItem><PaymentCatalogItem><PaymentCatalogID>26</PaymentCatalogID><CatalogName>钱包</CatalogName><CatalogCode>CtripWallet</CatalogCode><TipsToPay /><CatalogDescription>钱包</CatalogDescription><PaymentWayItems><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>CashAccountPay</PaymentWayID><PaymentWayName>账户余额</PaymentWayName><PaymentWayGlobalName /><PrepayType>CAPAY</PrepayType><SubPaySystem>9</SubPaySystem><PaySystemName>现金账户支付</PaySystemName><ActionMode>Manual</ActionMode><Descrption>账户余额(钱包)</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>TMPAY_XING</PaymentWayID><PaymentWayName>礼品卡-任我行</PaymentWayName><PaymentWayGlobalName /><PrepayType>TMPAY</PrepayType><SubPaySystem>7</SubPaySystem><PaySystemName>游票支付</PaySystemName><ActionMode>Manual</ActionMode><Descrption>礼品卡-任我行</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem></PaymentWayItems></PaymentCatalogItem><PaymentCatalogItem><PaymentCatalogID>30</PaymentCatalogID><CatalogName>钱包担保</CatalogName><CatalogCode>CtripWalletGuarantee</CatalogCode><TipsToPay /><PaymentWayItems><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>CashAccountPay_Guarantee</PaymentWayID><PaymentWayName>账户余额担保</PaymentWayName><PaymentWayGlobalName /><PrepayType>CAPAY</PrepayType><SubPaySystem>9</SubPaySystem><PaySystemName>现金账户支付</PaySystemName><ActionMode>Auto</ActionMode><Descrption>账户余额担保(钱包)</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem></PaymentWayItems></PaymentCatalogItem><PaymentCatalogItem><PaymentCatalogID>1</PaymentCatalogID><CatalogName>信用卡</CatalogName><CatalogCode>CreditCard</CatalogCode><TipsToPay /><CatalogDescription>&lt;p class='paycredit_info'&gt; 注意事项：预订距机票起飞时间24小时内的订单不提供境外信用卡支付,电话预订机票不提供境外信用卡支付和担保。&lt;/p&gt;</CatalogDescription><PaymentWayItems><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>1</CreditCardType><CreditCardBankID>1</CreditCardBankID><PaymentWayID>CC_BOC</PaymentWayID><PaymentWayName>中国银行</PaymentWayName><PaymentWayGlobalName>Bank of China</PaymentWayGlobalName><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Manual</ActionMode><Descrption /><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>15</CreditCardType><CreditCardBankID>15</CreditCardBankID><PaymentWayID>CC_CEBBANK</PaymentWayID><PaymentWayName>光大银行</PaymentWayName><PaymentWayGlobalName>China Everybright Bank</PaymentWayGlobalName><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Manual</ActionMode><Descrption /><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>11</CreditCardType><CreditCardBankID>11</CreditCardBankID><PaymentWayID>CC_CMB</PaymentWayID><PaymentWayName>招商银行</PaymentWayName><PaymentWayGlobalName>China Merchants Bank</PaymentWayGlobalName><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Manual</ActionMode><Descrption /><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>3</CreditCardType><CreditCardBankID>3</CreditCardBankID><PaymentWayID>CC_COMM</PaymentWayID><PaymentWayName>交通银行</PaymentWayName><PaymentWayGlobalName>China Communication Bank</PaymentWayGlobalName><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Auto</ActionMode><Descrption /><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>2</CreditCardType><CreditCardBankID>2</CreditCardBankID><PaymentWayID>CC_ICBC</PaymentWayID><PaymentWayName>工商银行</PaymentWayName><PaymentWayGlobalName>Industry &amp; Commercial Bank of China</PaymentWayGlobalName><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Auto</ActionMode><Descrption /><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>22</CreditCardType><CreditCardBankID>22</CreditCardBankID><PaymentWayID>CC_SDB</PaymentWayID><PaymentWayName>深发银行</PaymentWayName><PaymentWayGlobalName>Shenzhen Development Bank</PaymentWayGlobalName><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Manual</ActionMode><Descrption /><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>22</CreditCardType><CreditCardBankID>22</CreditCardBankID><PaymentWayID>CC_SPABANK</PaymentWayID><PaymentWayName>平安银行</PaymentWayName><PaymentWayGlobalName>Ping An Bank</PaymentWayGlobalName><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Manual</ActionMode><Descrption /><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem></PaymentWayItems></PaymentCatalogItem><PaymentCatalogItem><PaymentCatalogID>16</PaymentCatalogID><CatalogName>储蓄卡快捷</CatalogName><CatalogCode>DepositCard</CatalogCode><TipsToPay /><CatalogDescription>储蓄卡快捷</CatalogDescription><PaymentWayItems><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>1000</CreditCardType><CreditCardBankID>1128</CreditCardBankID><PaymentWayID>DQ_ABC</PaymentWayID><PaymentWayName>农业银行</PaymentWayName><PaymentWayGlobalName /><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Manual</ActionMode><Descrption>农业银行</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>1000</CreditCardType><CreditCardBankID>1129</CreditCardBankID><PaymentWayID>DQ_BOC</PaymentWayID><PaymentWayName>中国银行</PaymentWayName><PaymentWayGlobalName /><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Auto</ActionMode><Descrption>中国银行</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>1000</CreditCardType><CreditCardBankID>1130</CreditCardBankID><PaymentWayID>DQ_CCB</PaymentWayID><PaymentWayName>建设银行</PaymentWayName><PaymentWayGlobalName /><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Auto</ActionMode><Descrption>建设银行</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>1000</CreditCardType><CreditCardBankID>1138</CreditCardBankID><PaymentWayID>DQ_CIB</PaymentWayID><PaymentWayName>兴业银行</PaymentWayName><PaymentWayGlobalName /><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Auto</ActionMode><Descrption>兴业银行</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>1000</CreditCardType><CreditCardBankID>1137</CreditCardBankID><PaymentWayID>DQ_CMB</PaymentWayID><PaymentWayName>招商银行</PaymentWayName><PaymentWayGlobalName /><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Auto</ActionMode><Descrption>招商银行</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>1000</CreditCardType><CreditCardBankID>1135</CreditCardBankID><PaymentWayID>DQ_CMBC</PaymentWayID><PaymentWayName>民生银行</PaymentWayName><PaymentWayGlobalName /><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Auto</ActionMode><Descrption>民生银行</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>1000</CreditCardType><CreditCardBankID>1131</CreditCardBankID><PaymentWayID>DQ_COMM</PaymentWayID><PaymentWayName>交通银行</PaymentWayName><PaymentWayGlobalName /><PrepayType>CCARD</PrepayType><SubPaySystem>2</SubPaySystem><PaySystemName>银行卡支付</PaySystemName><ActionMode>Auto</ActionMode><Descrption>交通银行</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>true</IsSupportRealTime></PaymentWayItem></PaymentWayItems></PaymentCatalogItem><PaymentCatalogItem><PaymentCatalogID>31</PaymentCatalogID><CatalogName>礼品卡担保</CatalogName><CatalogCode>TMPayGuarantee</CatalogCode><TipsToPay /><PaymentWayItems><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>TMPAY_XING_Guarantee</PaymentWayID><PaymentWayName>礼品卡担保-任我行</PaymentWayName><PaymentWayGlobalName /><PrepayType>TMPAY</PrepayType><SubPaySystem>7</SubPaySystem><PaySystemName>游票支付</PaySystemName><ActionMode>Manual</ActionMode><Descrption>礼品卡担保-任我行</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>TMPAY_YOU_Guarantee</PaymentWayID><PaymentWayName>礼品卡担保-任我游</PaymentWayName><PaymentWayGlobalName /><PrepayType>TMPAY</PrepayType><SubPaySystem>7</SubPaySystem><PaySystemName>游票支付</PaySystemName><ActionMode>Manual</ActionMode><Descrption>礼品卡担保-任我游</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem><PaymentWayItem><IsSupportPreAuth>false</IsSupportPreAuth><CreditCardType>0</CreditCardType><CreditCardBankID>0</CreditCardBankID><PaymentWayID>TMPAY_ZHU_Guarantee</PaymentWayID><PaymentWayName>礼品卡担保-任我住</PaymentWayName><PaymentWayGlobalName /><PrepayType>TMPAY</PrepayType><SubPaySystem>7</SubPaySystem><PaySystemName>游票支付</PaySystemName><ActionMode>Manual</ActionMode><Descrption>礼品卡担保-任我住</Descrption><IsUsedCardAvailable>false</IsUsedCardAvailable><IsSupportRealTime>false</IsSupportRealTime></PaymentWayItem></PaymentWayItems></PaymentCatalogItem></PaymentCatalogs></InqurieMerchantPayWayResponse></Response>";
        }
    }
}
