using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Services;
using System.Xml;

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
        public string Request(string requestXML)
        {
            
            XmlDocument reqXml = new XmlDocument();
            reqXml.LoadXml(requestXML);

            XmlDocument xmlPattern = new XmlDocument();

            string req1 = @"<?xml version='1.0'?>
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
        </Request>";

            string res1 = @"<?xml version='1.0'?>
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
        </Response>";

            string req2 = @"<?xml version='1.0'?>
        <Request>
        <Header UserID='340101' RequestType='Payment.TMPay.Service.SelectCustomerTicketCollection' Culture='cn' RequestID='705adfd4-c562-4fe3-880d-47b6310cde0d' ClientIP='172.16.146.78' AsyncRequest='false' Timeout='0' MessagePriority='3' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fws' UseMemoryQ='false' />
        <SelectCustomerTicketCollectionRequest>
        <CustomerID>13811118888</CustomerID>
        </SelectCustomerTicketCollectionRequest>
        </Request>";
            string res2 = @"<?xml version='1.0'?>
        <Response>
        <Header ServerIP='10.2.6.47' ShouldRecordPerformanceTime='false' ResultCode='Success' ResultNo='0' ResultMsg='成功' RequestBodySize='0' SerializeMode='Xml' RouteStep='0' />
        <SelectCustomerTicketCollectionResponse>
        <TicketCollectionItemList />
        </SelectCustomerTicketCollectionResponse>
        </Response>";

            string req3 = @"<?xml version='1.0'?>
        <Request>
        <Header UserID='340101' RequestType='AccCash.CreditCard.GetCreditCardTypeInfo' Culture='cn' RequestID='e5925113-de7a-41af-a43a-6209477c036b' ClientIP='172.16.146.78' AsyncRequest='false' Timeout='0' MessagePriority='3' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fws' UseMemoryQ='false' />
        <GetCreditCardTypeInfoRequest>
        <CreditCardType>-2147483648</CreditCardType>
        </GetCreditCardTypeInfoRequest>
        </Request>";
            string res3 = @"<?xml version='1.0'?>
        <Response>
        <Header ServerIP='10.2.6.47' Culture='cn' ShouldRecordPerformanceTime='false' UserID='340101' RequestID='e5925113-de7a-41af-a43a-6209477c036b' ResultCode='Success' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fws' />
        <GetCreditCardTypeInfoResponse>
        <CreditCardTypeItems>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>1</CreditCardType>
        <CreditCardName>中国银行 -- 长城卡</CreditCardName>
        <CreditCardBig5Name>い瓣蝗︽ -- </CreditCardBig5Name>
        <CreditCardeName>Bank of China -- Great Wall Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>1</SeqID>
        <Bank>中国银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>BOC</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>F</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>3</CreditCardType>
        <CreditCardName>中国交通银行 -- 信用卡（贷记卡）</CreditCardName>
        <CreditCardBig5Name>い瓣ユ硄蝗︽ -- 獺ノ (禪癘)</CreditCardBig5Name>
        <CreditCardeName>China Communication Bank -- Pacific Card (Shanghai)</CreditCardeName>
        <Active>T</Active>
        <SeqID>3</SeqID>
        <Bank>中国交通银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>CTB</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>F</UseHtlPay>
        <UseHtlGuarantee>F</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>F</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>4</CreditCardType>
        <CreditCardName>中国农业银行 -- 金穗卡</CreditCardName>
        <CreditCardBig5Name>い瓣笰穨蝗︽ -- 罦</CreditCardBig5Name>
        <CreditCardeName>Agricultural Bank of China -- Credit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>4</SeqID>
        <Bank>中国农业银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>AB</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>5</CreditCardType>
        <CreditCardName>中国建设银行 -- 信用卡（贷记卡）</CreditCardName>
        <CreditCardBig5Name>い瓣砞蝗︽ -- 獺ノ (禪癘)</CreditCardBig5Name>
        <CreditCardeName>China Construction Bank -- Long Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>5</SeqID>
        <Bank>中国建设银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>A         </ActionMode>
        <BankShortName>CCB</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>11</CreditCardType>
        <CreditCardName>中国招商银行 -- 信用卡</CreditCardName>
        <CreditCardBig5Name>锟斤拷锟斤拷锟桔坝蝗︼拷 -- 锟斤拷锟节</CreditCardBig5Name>
        <CreditCardeName>China Merchants Bank -- Credit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>6</SeqID>
        <Bank>中国招商银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>CMB</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>6</CreditCardType>
        <CreditCardName>锟斤拷锟解发锟斤拷锟斤拷锟矫匡拷 -- 锟斤拷锟铰达拷</CreditCardName>
        <CreditCardBig5Name>锟揭锟給锟斤拷锟紿锟轿 -- 锟経锟狡笷(Master)</CreditCardBig5Name>
        <CreditCardeName>Overseas Issued Credit card -- Master Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>7</SeqID>
        <Bank>锟斤拷锟铰达卡</Bank>
        <CreditCardNational>I</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>MASTER</BankShortName>
        <ListParameter>32</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name>锟斤拷锟节 -- 锟経锟狡笷(Master)</HK_Big5Name>
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>F</UseCorpHtlPay>
        <UseCorpHtlGuarantee>F</UseCorpHtlGuarantee>
        <UseCorpFltPay>F</UseCorpFltPay>
        <UseCorpFltGuarantee>F</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>T</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>7</CreditCardType>
        <CreditCardName>境外发行信用卡 -- 威士(VISA)</CreditCardName>
        <CreditCardBig5Name>挂祇︽獺ノ -- (VISA)</CreditCardBig5Name>
        <CreditCardeName>Overseas Issued Credit card -- Visa Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>8</SeqID>
        <Bank>威士卡</Bank>
        <CreditCardNational>I</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>VISA</BankShortName>
        <ListParameter>32</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name>瓣悔 -- (VISA)</HK_Big5Name>
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>F</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>F</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>8</CreditCardType>
        <CreditCardName>境外发行信用卡 -- 运通(AMEX)</CreditCardName>
        <CreditCardBig5Name>挂祇︽獺ノ -- 笲硄(AMEX)</CreditCardBig5Name>
        <CreditCardeName>Overseas Issued Credit card -- American Express Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>9</SeqID>
        <Bank>运通卡</Bank>
        <CreditCardNational>I</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>AMEX</BankShortName>
        <ListParameter>32</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name>瓣悔 -- 笲硄(AMEX)</HK_Big5Name>
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>T</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>9</CreditCardType>
        <CreditCardName>境外发行信用卡 -- 大来(Diners Club)</CreditCardName>
        <CreditCardBig5Name>挂祇︽獺ノ -- ㄓ(Diners Club)</CreditCardBig5Name>
        <CreditCardeName>Overseas Issued Credit card -- Diners Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>10</SeqID>
        <Bank>大来卡</Bank>
        <CreditCardNational>I</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>DC</BankShortName>
        <ListParameter>32</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name>瓣悔 -- ㄓ(Diners Club)</HK_Big5Name>
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>10</CreditCardType>
        <CreditCardName>境外发行信用卡 -- JCB</CreditCardName>
        <CreditCardBig5Name>挂祇︽獺ノ -- JCB</CreditCardBig5Name>
        <CreditCardeName>Overseas Issued Credit card -- JCB Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>11</SeqID>
        <Bank>JCB卡</Bank>
        <CreditCardNational>I</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>JCB</BankShortName>
        <ListParameter>32</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name>瓣悔 -- JCB</HK_Big5Name>
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>13</CreditCardType>
        <CreditCardName>广东发展银行 -- 信用卡</CreditCardName>
        <CreditCardBig5Name>約狥祇甶蝗︽ -- 獺ノ</CreditCardBig5Name>
        <CreditCardeName>Guangdong Development Bank -- Credit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>13</SeqID>
        <Bank>广东发展银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>GDB</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>F</UseFltPay>
        <UseFltGuarantee>F</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>14</CreditCardType>
        <CreditCardName>国内发行银联卡</CreditCardName>
        <CreditCardBig5Name>国内发行银联卡</CreditCardBig5Name>
        <CreditCardeName>国内发行银联卡</CreditCardeName>
        <Active>F</Active>
        <SeqID>14</SeqID>
        <Bank>国内发行银联卡</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName />
        <ListParameter>0</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>15</CreditCardType>
        <CreditCardName>中国光大银行 -- 阳光卡</CreditCardName>
        <CreditCardBig5Name>い瓣蝗︽ -- 锭</CreditCardBig5Name>
        <CreditCardeName>China Everybright Bank -- Credit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>15</SeqID>
        <Bank>中国光大银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>CEB</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>F</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>16</CreditCardType>
        <CreditCardName>中国民生银行 -- 信用卡</CreditCardName>
        <CreditCardBig5Name>い瓣チネ蝗︽ -- 獺ノ</CreditCardBig5Name>
        <CreditCardeName>China Minsheng Banking -- Credit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>16</SeqID>
        <Bank>中国民生银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>CMBC</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>F</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>F</UseCorpHtlPay>
        <UseCorpHtlGuarantee>F</UseCorpHtlGuarantee>
        <UseCorpFltPay>F</UseCorpFltPay>
        <UseCorpFltGuarantee>F</UseCorpFltGuarantee>
        <UseCorpPkgPay>F</UseCorpPkgPay>
        <UseCorpPkgGuarantee>F</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>17</CreditCardType>
        <CreditCardName>中信银行 -- 信用卡</CreditCardName>
        <CreditCardBig5Name>い獺蝗︽ -- 獺ノ</CreditCardBig5Name>
        <CreditCardeName>China CITIC Bank -- Credit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>17</SeqID>
        <Bank>中信银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>A         </ActionMode>
        <BankShortName>CIBC</BankShortName>
        <ListParameter>59</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>18</CreditCardType>
        <CreditCardName>上海浦东发展银行 -- 信用卡</CreditCardName>
        <CreditCardBig5Name>狥祇甶蝗︽ -- 獺ノ</CreditCardBig5Name>
        <CreditCardeName>Shanghai Pudong Development Bank -- Credit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>18</SeqID>
        <Bank>浦东发展银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>SPDBC</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>19</CreditCardType>
        <CreditCardName>携程银行 -- 商旅业务担保卡</CreditCardName>
        <CreditCardBig5Name>拟祘蝗︽ -- 皊┍踞玂</CreditCardBig5Name>
        <CreditCardeName>Ctrip Bank -- Corporate Travel Guarantees Credit Card</CreditCardeName>
        <Active>F</Active>
        <SeqID>19</SeqID>
        <Bank>携程银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName />
        <ListParameter>0</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>20</CreditCardType>
        <CreditCardName>兴业银行 -- 信用卡</CreditCardName>
        <CreditCardBig5Name>砍穨蝗︽-- 獺ノ</CreditCardBig5Name>
        <CreditCardeName>Industrial Bank Co.ltd -- Credit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>20</SeqID>
        <Bank>兴业银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>CIB</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>F</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>21</CreditCardType>
        <CreditCardName>上海银行 -- 信用卡</CreditCardName>
        <CreditCardBig5Name>蝗︽ -- 獺ノ</CreditCardBig5Name>
        <CreditCardeName>Bank of Shanghai</CreditCardeName>
        <Active>T</Active>
        <SeqID>21</SeqID>
        <Bank>上海银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>BOS</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>F</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>22</CreditCardType>
        <CreditCardName>深圳平安银行--平安万里通信用卡</CreditCardName>
        <CreditCardBig5Name>瞏キ蝗︽--キ窾ń硄獺ノ</CreditCardBig5Name>
        <CreditCardeName>Ping An of China.ShenZhen Ping An Bank</CreditCardeName>
        <Active>T</Active>
        <SeqID>22</SeqID>
        <Bank>深圳平安银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>PASCB</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>F</UseCorpHtlPay>
        <UseCorpHtlGuarantee>F</UseCorpHtlGuarantee>
        <UseCorpFltPay>F</UseCorpFltPay>
        <UseCorpFltGuarantee>F</UseCorpFltGuarantee>
        <UseCorpPkgPay>F</UseCorpPkgPay>
        <UseCorpPkgGuarantee>F</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>23</CreditCardType>
        <CreditCardName>发展信用卡--深圳发展银行</CreditCardName>
        <CreditCardBig5Name>祇甶獺ノ--瞏祇甶蝗︽</CreditCardBig5Name>
        <CreditCardeName>Shenzhen Development Bank</CreditCardeName>
        <Active>T</Active>
        <SeqID>23</SeqID>
        <Bank>深圳发展银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>SDBC</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>25</CreditCardType>
        <CreditCardName>宁波银行 -- 信用卡</CreditCardName>
        <CreditCardBig5Name>圭猧蝗︽ -- 獺ノ</CreditCardBig5Name>
        <CreditCardeName>Bank of Ningbo -- Debit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>25</SeqID>
        <Bank>宁波银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>NBCB</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>26</CreditCardType>
        <CreditCardName>东亚银行 -- 信用卡</CreditCardName>
        <CreditCardBig5Name>狥ㄈ蝗︽ -- 獺ノ</CreditCardBig5Name>
        <CreditCardeName>Bank of East Asia -- Credit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>26</SeqID>
        <Bank>东亚银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>BEA</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>27</CreditCardType>
        <CreditCardName>北京银行 -- 信用卡</CreditCardName>
        <CreditCardBig5Name>ㄊ蝗︽ -- 獺ノ</CreditCardBig5Name>
        <CreditCardeName>Bank of Beijing</CreditCardeName>
        <Active>T</Active>
        <SeqID>27</SeqID>
        <Bank>北京银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>BOB</BankShortName>
        <ListParameter>127</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>F</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>28</CreditCardType>
        <CreditCardName>江苏银行--信用卡</CreditCardName>
        <CreditCardBig5Name>江蘇銀行</CreditCardBig5Name>
        <CreditCardeName>Bank of JiangSu--Credit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>28</SeqID>
        <Bank>江苏银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>JSBK</BankShortName>
        <ListParameter>63</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>F</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>F</UsePkgGuarantee>
        <UseCorpHtlPay>F</UseCorpHtlPay>
        <UseCorpHtlGuarantee>F</UseCorpHtlGuarantee>
        <UseCorpFltPay>F</UseCorpFltPay>
        <UseCorpFltGuarantee>F</UseCorpFltGuarantee>
        <UseCorpPkgPay>F</UseCorpPkgPay>
        <UseCorpPkgGuarantee>F</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>66</CreditCardType>
        <CreditCardName>境外发行信用卡 -- 万事达(Master)</CreditCardName>
        <CreditCardBig5Name>挂祇︽獺ノ -- 窾ㄆ笷(Master)</CreditCardBig5Name>
        <CreditCardeName>Overseas Issued Credit card -- Master Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>66</SeqID>
        <Bank>万事达卡</Bank>
        <CreditCardNational>I</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>MASTER</BankShortName>
        <ListParameter>32</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name>瓣悔 -- 窾ㄆ笷(Master)</HK_Big5Name>
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>F</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>67</CreditCardType>
        <CreditCardName>境外发行信用卡 -- 万事达(Master)</CreditCardName>
        <CreditCardBig5Name>挂祇︽獺ノ -- 窾ㄆ笷(Master)</CreditCardBig5Name>
        <CreditCardeName>Overseas Issued Credit card -- Master Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>67</SeqID>
        <Bank>万事达卡</Bank>
        <CreditCardNational>I</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>MASTER</BankShortName>
        <ListParameter>32</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name>瓣悔 -- 窾ㄆ笷(Master)</HK_Big5Name>
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>F</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>76</CreditCardType>
        <CreditCardName>境外发行信用卡 -- 威士(VISA)</CreditCardName>
        <CreditCardBig5Name>挂祇︽獺ノ -- (VISA)</CreditCardBig5Name>
        <CreditCardeName>Overseas Issued Credit card -- Visa Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>76</SeqID>
        <Bank>威士卡</Bank>
        <CreditCardNational>I</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>VISA</BankShortName>
        <ListParameter>32</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name>瓣悔 -- (VISA)</HK_Big5Name>
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>77</CreditCardType>
        <CreditCardName>境外发行信用卡 -- 威士(VISA)</CreditCardName>
        <CreditCardBig5Name>挂祇︽獺ノ -- (VISA)</CreditCardBig5Name>
        <CreditCardeName>Overseas Issued Credit card -- Visa Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>77</SeqID>
        <Bank>威士卡</Bank>
        <CreditCardNational>I</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>VISA</BankShortName>
        <ListParameter>32</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name>瓣悔 -- (VISA)</HK_Big5Name>
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>78</CreditCardType>
        <CreditCardName>花旗银行-信用卡</CreditCardName>
        <CreditCardBig5Name />
        <CreditCardeName>Citibank, N.A</CreditCardeName>
        <Active>T</Active>
        <SeqID>78</SeqID>
        <Bank>花旗银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>A         </ActionMode>
        <BankShortName>Citibank</BankShortName>
        <ListParameter>127</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>24</CreditCardType>
        <CreditCardName>华夏银行-信用卡</CreditCardName>
        <CreditCardBig5Name />
        <CreditCardeName>Bank of Huaxia</CreditCardeName>
        <Active>T</Active>
        <SeqID>80</SeqID>
        <Bank>华夏银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>A         </ActionMode>
        <BankShortName>HX</BankShortName>
        <ListParameter>127</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>F</UseNewSystem>
        <HK_Big5Name>华夏银行-信用卡</HK_Big5Name>
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>F</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>F</UsePkgPay>
        <UsePkgGuarantee>F</UsePkgGuarantee>
        <UseCorpHtlPay>F</UseCorpHtlPay>
        <UseCorpHtlGuarantee>F</UseCorpHtlGuarantee>
        <UseCorpFltPay>F</UseCorpFltPay>
        <UseCorpFltGuarantee>F</UseCorpFltGuarantee>
        <UseCorpPkgPay>F</UseCorpPkgPay>
        <UseCorpPkgGuarantee>F</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>101</CreditCardType>
        <CreditCardName>中国工商银行 -- 直付通</CreditCardName>
        <CreditCardBig5Name>い瓣坝蝗︽ -- 癘</CreditCardBig5Name>
        <CreditCardeName>Industry &amp;amp; Commercial Bank of China -- Debit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>101</SeqID>
        <Bank>工商银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>A         </ActionMode>
        <BankShortName>ICBC</BankShortName>
        <ListParameter>0</ListParameter>
        <IsJJK>T</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>F</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>102</CreditCardType>
        <CreditCardName>中国招商银行 -- 借记卡</CreditCardName>
        <CreditCardBig5Name>い瓣┷坝蝗︽ -- 癘</CreditCardBig5Name>
        <CreditCardeName>China Merchants Bank -- Debit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>102</SeqID>
        <Bank>中国招商银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>CMB</BankShortName>
        <ListParameter>0</ListParameter>
        <IsJJK>T</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
       <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>103</CreditCardType>
        <CreditCardName>中国招商银行 -- 直付通</CreditCardName>
        <CreditCardBig5Name>い瓣┷坝蝗︽ -- 癘</CreditCardBig5Name>
        <CreditCardeName>China Merchants Bank -- Debit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>103</SeqID>
        <Bank>中国招商银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>A         </ActionMode>
        <BankShortName>CMB</BankShortName>
        <ListParameter>0</ListParameter>
        <IsJJK>T</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardType>105</CreditCardType>
        <CreditCardName>银联手机支付通</CreditCardName>
        <CreditCardBig5Name>蝗羛も诀や硄</CreditCardBig5Name>
        <CreditCardeName>China UnionPay Telephone -- Debit Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>105</SeqID>
        <Bank>银联手机支付通</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>A         </ActionMode>
        <BankShortName>CU</BankShortName>
        <ListParameter>32</ListParameter>
        <IsJJK>T</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>106</CreditCardType>
        <CreditCardName>境外发行信用卡 -- JCB</CreditCardName>
        <CreditCardBig5Name>挂祇︽獺ノ -- JCB</CreditCardBig5Name>
        <CreditCardeName>Overseas Issued Credit card -- JCB Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>106</SeqID>
        <Bank>JCB卡</Bank>
        <CreditCardNational>I</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>JCB</BankShortName>
        <ListParameter>32</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name>瓣悔 -- JCB</HK_Big5Name>
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>107</CreditCardType>
        <CreditCardName>境外发行信用卡 -- JCB</CreditCardName>
        <CreditCardBig5Name>挂祇︽獺ノ -- JCB</CreditCardBig5Name>
        <CreditCardeName>Overseas Issued Credit card -- JCB Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>107</SeqID>
        <Bank>JCB卡</Bank>
        <CreditCardNational>I</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName>JCB</BankShortName>
        <ListParameter>32</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name>瓣悔 -- JCB</HK_Big5Name>
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>T</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>200</CreditCardType>
        <CreditCardName>银联信用卡-标准/非标准(冲突无效)</CreditCardName>
        <CreditCardBig5Name />
        <CreditCardeName>UnionPay creditcard-Standard/Nonstandard</CreditCardeName>
        <Active>T</Active>
        <SeqID>200</SeqID>
        <Bank>银联信用卡</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName />
        <ListParameter>0</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>F</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>F</UseFltGuarantee>
        <UsePkgPay>F</UsePkgPay>
        <UsePkgGuarantee>F</UsePkgGuarantee>
        <UseCorpHtlPay>F</UseCorpHtlPay>
        <UseCorpHtlGuarantee>F</UseCorpHtlGuarantee>
        <UseCorpFltPay>F</UseCorpFltPay>
        <UseCorpFltGuarantee>F</UseCorpFltGuarantee>
        <UseCorpPkgPay>F</UseCorpPkgPay>
        <UseCorpPkgGuarantee>F</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>T</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>2</CreditCardType>
        <CreditCardName>中国工商银行 -- 牡丹卡</CreditCardName>
        <CreditCardBig5Name>い瓣坝蝗︽ -- ╠う</CreditCardBig5Name>
        <CreditCardeName>Industry &amp;amp; Commercial Bank of China -- Peony Card</CreditCardeName>
        <Active>T</Active>
        <SeqID>254</SeqID>
        <Bank>中国工商银行</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>A         </ActionMode>
        <BankShortName>ICBC</BankShortName>
        <ListParameter>127</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>T</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>F</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>500</CreditCardType>
        <CreditCardName>锟斤拷锟斤拷锟斤拷锟矫匡拷-锟斤拷准/锟角憋拷准(500</CreditCardName>
        <CreditCardBig5Name />
        <CreditCardeName>UnionPay creditcard-Standard/Nonstandard</CreditCardeName>
        <Active>T</Active>
        <SeqID>500</SeqID>
        <Bank>锟斤拷锟斤拷锟斤拷锟矫匡拷</Bank>
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>A         </ActionMode>
        <BankShortName />
        <ListParameter>127</ListParameter>
        <IsJJK>F</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>F</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>F</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>F</UsePkgGuarantee>
        <UseCorpHtlPay>F</UseCorpHtlPay>
        <UseCorpHtlGuarantee>F</UseCorpHtlGuarantee>
        <UseCorpFltPay>F</UseCorpFltPay>
        <UseCorpFltGuarantee>F</UseCorpFltGuarantee>
        <UseCorpPkgPay>F</UseCorpPkgPay>
        <UseCorpPkgGuarantee>F</UseCorpPkgGuarantee>
        <BVerifyNo>T</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>T</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        <CreditCardTypeInfoResponseItem>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardType>1000</CreditCardType>
        <CreditCardName>银联储蓄卡快捷</CreditCardName>
        <CreditCardBig5Name />
        <CreditCardeName>DepositCard</CreditCardeName>
        <Active>T</Active>
        <SeqID>1000</SeqID>
        <Bank />
        <CreditCardNational>N</CreditCardNational>
        <ActionMode>H         </ActionMode>
        <BankShortName />
        <ListParameter>127</ListParameter>
        <IsJJK>T</IsJJK>
        <UseNewSystem>T</UseNewSystem>
        <HK_Big5Name />
        <UseHtlPay>T</UseHtlPay>
        <UseHtlGuarantee>T</UseHtlGuarantee>
        <UseFltPay>T</UseFltPay>
        <UseFltGuarantee>T</UseFltGuarantee>
        <UsePkgPay>T</UsePkgPay>
        <UsePkgGuarantee>T</UsePkgGuarantee>
        <UseCorpHtlPay>T</UseCorpHtlPay>
        <UseCorpHtlGuarantee>T</UseCorpHtlGuarantee>
        <UseCorpFltPay>T</UseCorpFltPay>
        <UseCorpFltGuarantee>T</UseCorpFltGuarantee>
        <UseCorpPkgPay>T</UseCorpPkgPay>
        <UseCorpPkgGuarantee>T</UseCorpPkgGuarantee>
        <BVerifyNo>F</BVerifyNo>
        <BUseGreen>F</BUseGreen>
        <IsNeedForeignCardExtend>F</IsNeedForeignCardExtend>
        <IsNeedPhoneNo>T</IsNeedPhoneNo>
        </CreditCardTypeInfoResponseItem>
        </CreditCardTypeItems>
        </GetCreditCardTypeInfoResponse>
        </Response>";

            string req4 = @"<?xml version='1.0'?>
        <Request>
        <Header UserID='340101' RequestType='AccCash.CreditCard.GetPayUsedListInfoNew' RequestID='d91af7a2-4024-47ba-bc27-de3d82115ec0' ClientIP='172.16.146.78' AsyncRequest='false' Timeout='0' MessagePriority='3' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fws' UseMemoryQ='false' />
        <GetPayUsedListInfoNewRequest>
        <Uid>13811118888</Uid>
        <CreditCardType>-2147483648</CreditCardType>
        <PathType>G</PathType>
        </GetPayUsedListInfoNewRequest>
        </Request>";
            string res4 = @"<?xml version='1.0'?>
        <Response>
        <Header ServerIP='10.2.6.47' ShouldRecordPerformanceTime='false' UserID='340101' RequestID='d91af7a2-4024-47ba-bc27-de3d82115ec0' ResultCode='Success' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fws' />
        <GetPayUsedListInfoNewResponse>
        <PayUsedListNewItems>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2480789</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>439226******9140</CardNoTenCode>
        <CreditCardType>11</CreditCardType>
        <ChannelStatus>T</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30032988</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-08-25T16:52:54.583</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRPFA29602DF1D42BC43C68506D59BDD42B</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>439226|40</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2480789</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>439226******9140</CardNoTenCode>
        <CreditCardType>57</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30032988</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-08-25T16:52:54.583</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRPFA29602DF1D42BC43C68506D59BDD42B</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>439226|40</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2480789</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>439226******9140</CardNoTenCode>
        <CreditCardType>76</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30032988</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-08-25T16:52:54.583</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRPFA29602DF1D42BC43C68506D59BDD42B</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>439226|40</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2480789</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>439226******9140</CardNoTenCode>
        <CreditCardType>77</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30032988</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-08-25T16:52:54.583</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRPFA29602DF1D42BC43C68506D59BDD42B</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>439226|40</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2480789</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>439226******9140</CardNoTenCode>
        <CreditCardType>558</CreditCardType>
        <ChannelStatus>T</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30032988</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-08-25T16:52:54.583</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRPFA29602DF1D42BC43C68506D59BDD42B</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>T</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>439226|40</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2483509</RecordID>
        <Uid>13811118888</Uid>
        <CardNoTenCode>622922******2003</CardNoTenCode>
        <CreditCardType>20</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29548218</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-11-04T15:37:59.7</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>622922|03</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2483509</RecordID>
        <Uid>13811118888</Uid>
        <CardNoTenCode>622922******2003</CardNoTenCode>
        <CreditCardType>564</CreditCardType>
        <ChannelStatus>T</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29548218</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-11-04T15:37:59.7</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>T</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>622922|03</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2481452</RecordID>
        <Uid>13811118888</Uid>
        <CardNoTenCode>622588******9791</CardNoTenCode>
        <CreditCardType>102</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30026916</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-09-05T10:34:45.057</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP3C1A3ECFC56F7B64F8890ACF80497BC5</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>622588|91</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2481452</RecordID>
        <Uid>13811118888</Uid>
        <CardNoTenCode>622588******9791</CardNoTenCode>
        <CreditCardType>1137</CreditCardType>
        <ChannelStatus>T</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30026916</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-09-05T10:34:45.057</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP3C1A3ECFC56F7B64F8890ACF80497BC5</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>T</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>622588|91</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2481452</RecordID>
        <Uid>13811118888</Uid>
        <CardNoTenCode>622588******9791</CardNoTenCode>
        <CreditCardType>1</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30026916</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-09-05T10:34:45.057</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP3C1A3ECFC56F7B64F8890ACF80497BC5</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>622588|91</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2483530</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>427020******2555</CardNoTenCode>
        <CreditCardType>2</CreditCardType>
        <ChannelStatus>T</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30031180</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-11-05T15:07:58.183</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>427020|55</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2483530</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>427020******2555</CardNoTenCode>
        <CreditCardType>57</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30031180</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-11-05T15:07:58.183</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>427020|55</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2483530</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>427020******2555</CardNoTenCode>
        <CreditCardType>76</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30031180</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-11-05T15:07:58.183</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>427020|55</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2483530</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>427020******2555</CardNoTenCode>
        <CreditCardType>77</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30031180</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-11-05T15:07:58.183</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>427020|55</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2483530</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>427020******2555</CardNoTenCode>
        <CreditCardType>554</CreditCardType>
        <ChannelStatus>T</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>30031180</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-11-05T15:07:58.183</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>T</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>427020|55</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2479009</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>300000******0004</CardNoTenCode>
        <CreditCardType>9</CreditCardType>
        <ChannelStatus>T</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29280194</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-07-22T11:13:33.61</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRP88D82DF4CD1EC9C0EEA57B73D5C389C2</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>300000|04</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2479009</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>300000******0004</CardNoTenCode>
        <CreditCardType>59</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29280194</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-07-22T11:13:33.61</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRP88D82DF4CD1EC9C0EEA57B73D5C389C2</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>300000|04</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2484201</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>407405******0008</CardNoTenCode>
        <CreditCardType>16</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>G</CardStatus>
        <CardInfoId>30026927</CardInfoId>
        <PCPass>F</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-12-03T11:05:03.97</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP09369F80BB5CBCA3320A2FB847387DCA</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>407405|08</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2484201</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>407405******0008</CardNoTenCode>
        <CreditCardType>57</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>G</CardStatus>
        <CardInfoId>30026927</CardInfoId>
        <PCPass>F</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-12-03T11:05:03.97</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRP09369F80BB5CBCA3320A2FB847387DCA</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>407405|08</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2484201</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>407405******0008</CardNoTenCode>
        <CreditCardType>76</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>G</CardStatus>
        <CardInfoId>30026927</CardInfoId>
        <PCPass>F</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-12-03T11:05:03.97</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRP09369F80BB5CBCA3320A2FB847387DCA</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>407405|08</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2484201</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>407405******0008</CardNoTenCode>
        <CreditCardType>77</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>G</CardStatus>
        <CardInfoId>30026927</CardInfoId>
        <PCPass>F</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-12-03T11:05:03.97</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRP09369F80BB5CBCA3320A2FB847387DCA</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>407405|08</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2484201</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>407405******0008</CardNoTenCode>
        <CreditCardType>561</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>G</CardStatus>
        <CardInfoId>30026927</CardInfoId>
        <PCPass>F</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-12-03T11:05:03.97</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP09369F80BB5CBCA3320A2FB847387DCA</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>T</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>407405|08</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2484180</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>622346******1002</CardNoTenCode>
        <CreditCardType>1</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>G</CardStatus>
        <CardInfoId>30026224</CardInfoId>
        <PCPass>F</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-12-02T14:29:02.303</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP98D37F84AA7563C7816C9A841325C95D</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>622346|02</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2484180</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>622346******1002</CardNoTenCode>
        <CreditCardType>553</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>G</CardStatus>
        <CardInfoId>30026224</CardInfoId>
        <PCPass>F</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-12-02T14:29:02.303</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP98D37F84AA7563C7816C9A841325C95D</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>T</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>622346|02</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2483529</RecordID>
        <Uid>13811118888</Uid>
        <CardNoTenCode>402791******0001</CardNoTenCode>
        <CreditCardType>2</CreditCardType>
        <ChannelStatus>T</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29548438</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-11-05T14:59:20.473</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
       <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>402791|01</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2483529</RecordID>
        <Uid>13811118888</Uid>
        <CardNoTenCode>402791******0001</CardNoTenCode>
        <CreditCardType>57</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29548438</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-11-05T14:59:20.473</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>402791|01</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2483529</RecordID>
        <Uid>13811118888</Uid>
        <CardNoTenCode>402791******0001</CardNoTenCode>
        <CreditCardType>76</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29548438</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-11-05T14:59:20.473</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>402791|01</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2483529</RecordID>
        <Uid>13811118888</Uid>
        <CardNoTenCode>402791******0001</CardNoTenCode>
        <CreditCardType>77</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29548438</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-11-05T14:59:20.473</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>402791|01</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2483529</RecordID>
        <Uid>13811118888</Uid>
        <CardNoTenCode>402791******0001</CardNoTenCode>
        <CreditCardType>1127</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29548438</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-11-05T14:59:20.473</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>T</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>402791|01</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2482808</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>439225******0009</CardNoTenCode>
        <CreditCardType>11</CreditCardType>
        <ChannelStatus>T</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29546748</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-10-14T14:23:01.077</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>F</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRPD7CC4B9C6A3CE27A0805E0503D84AAAF</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>439225|09</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2482808</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>439225******0009</CardNoTenCode>
        <CreditCardType>57</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29546748</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-10-14T14:23:01.077</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRPD7CC4B9C6A3CE27A0805E0503D84AAAF</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>439225|09</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2482808</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>439225******0009</CardNoTenCode>
        <CreditCardType>76</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29546748</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-10-14T14:23:01.077</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRPD7CC4B9C6A3CE27A0805E0503D84AAAF</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>439225|09</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2482808</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>439225******0009</CardNoTenCode>
        <CreditCardType>77</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29546748</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-10-14T14:23:01.077</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>F</BIdType>
        <BIdNumber>F</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardNational>I</CreditCardNational>
        <Validity>CTRPD7CC4B9C6A3CE27A0805E0503D84AAAF</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>F</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>439225|09</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2482808</RecordID>
        <Uid>13811118888         </Uid>
        <CardNoTenCode>439225******0009</CardNoTenCode>
        <CreditCardType>558</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>T</CardStatus>
        <CardInfoId>29546748</CardInfoId>
        <PCPass>T</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-10-14T14:23:01.077</CreateDate>
        <BVerifyNo>T</BVerifyNo>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRPD7CC4B9C6A3CE27A0805E0503D84AAAF</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>T</IsNeedPhone>
        <IsNeedValidity>F</IsNeedValidity>
        <ShowCardNo>439225|09</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        <PayUsedListInfoNewResponseItem>
        <RecordID>2481984</RecordID>
        <Uid>13811118888</Uid>
        <CardNoTenCode>622588******6569</CardNoTenCode>
        <CreditCardType>1137</CreditCardType>
        <ChannelStatus>G</ChannelStatus>
        <CardStatus>G</CardStatus>
        <CardInfoId>29275841</CardInfoId>
        <PCPass>F</PCPass>
        <GCPass>T</GCPass>
        <CreateDate>2014-09-22T19:14:35.38</CreateDate>
        <BVerifyNo>F</BVerifyNo>
        <BIdType>T</BIdType>
        <BIdNumber>T</BIdNumber>
        <BCardHolder>T</BCardHolder>
        <CreditCardNational>N</CreditCardNational>
        <Validity>CTRP3C1A3ECFC56F7B64F8890ACF80497BC5</Validity>
        <IsBlackCard>F</IsBlackCard>
        <IsNeedPhone>T</IsNeedPhone>
        <IsNeedValidity>T</IsNeedValidity>
        <ShowCardNo>622588|69</ShowCardNo>
        </PayUsedListInfoNewResponseItem>
        </PayUsedListNewItems>
        </GetPayUsedListInfoNewResponse>
        </Response>";

            string req5 = @"<?xml version='1.0'?>
        <Request>
        <Header UserID='340101' RequestType='AccCash.CreditCard.GetCreditCardInfo' RequestID='29cd1035-74a7-466a-bb95-88f4370e030a' ClientIP='172.16.146.78' AsyncRequest='false' Timeout='0' MessagePriority='3' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fws' UseMemoryQ='false' />
        <GetCreditCardInfoRequest>
        <CardInfoId>30032988</CardInfoId>
        <CardInfoId>30032988</CardInfoId>
        <CardInfoId>30032988</CardInfoId>
        <CardInfoId>30032988</CardInfoId>
        <CardInfoId>30032988</CardInfoId>
        <CardInfoId>29548218</CardInfoId>
        <CardInfoId>29548218</CardInfoId>
        <CardInfoId>30026916</CardInfoId>
        <CardInfoId>30026916</CardInfoId>
        <CardInfoId>30026916</CardInfoId>
        <CardInfoId>30031180</CardInfoId>
        <CardInfoId>30031180</CardInfoId>
        <CardInfoId>30031180</CardInfoId>
        <CardInfoId>30031180</CardInfoId>
        <CardInfoId>30031180</CardInfoId>
        <CardInfoId>29280194</CardInfoId>
        <CardInfoId>29280194</CardInfoId>
        <CardInfoId>30026927</CardInfoId>
        <CardInfoId>30026927</CardInfoId>
        <CardInfoId>30026927</CardInfoId>
        <CardInfoId>30026927</CardInfoId>
        <CardInfoId>30026927</CardInfoId>
        <CardInfoId>30026224</CardInfoId>
        <CardInfoId>30026224</CardInfoId>
        <CardInfoId>29548438</CardInfoId>
        <CardInfoId>29548438</CardInfoId>
        <CardInfoId>29548438</CardInfoId>
        <CardInfoId>29548438</CardInfoId>
        <CardInfoId>29548438</CardInfoId>
        <CardInfoId>29546748</CardInfoId>
        <CardInfoId>29546748</CardInfoId>
        <CardInfoId>29546748</CardInfoId>
        <CardInfoId>29546748</CardInfoId>
        <CardInfoId>29546748</CardInfoId>
        <CardInfoId>29275841</CardInfoId>
        </GetCreditCardInfoRequest>
        </Request>";

            string res5 = @"<?xml version='1.0'?>
        <Response>
        <Header ServerIP='10.2.6.47' ShouldRecordPerformanceTime='false' UserID='340101' RequestID='29cd1035-74a7-466a-bb95-88f4370e030a' ResultCode='Success' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fws' />
        <GetCreditCardInfoResponse>
        <CreditCardItems>
        <CreditCardInfoResponseItem>
        <CardInfoId>29275841</CardInfoId>
        <CreditCardType>1137</CreditCardType>
        <CardTypeName>储蓄卡快捷（招商银行）</CardTypeName>
        <CreditCardNumber>CTRP8F0848DD2FD0F801DC15079EEE39AD7C</CreditCardNumber>
        <CCardNoCode>FEE868DF33F82A64C59B01189908D00C</CCardNoCode>
        <CValidityCode>EC7D9D60222157632EF18B0B5EE99F38</CValidityCode>
        <CardBin>622588</CardBin>
        <Validity>CTRP3C1A3ECFC56F7B64F8890ACF80497BC5</Validity>
        <CardHolder>嗯嗯额</CardHolder>
        <IdCardType>2</IdCardType>
        <IdNumber>34g5555555555555555555555555555555555</IdNumber>
        <VerifyNo>CTRP82D9B4999CACFFFF63A02E6CE5A3A282</VerifyNo>
        <CurrencyType>U</CurrencyType>
        <VM_Type>U</VM_Type>
        <IsForeignCard>F</IsForeignCard>
        <LocalCardType>U</LocalCardType>
        <AgreementCode />
        <Nationality />
        <StateName />
        <BillingAddress />
        <ZipCode />
        <Nationalityofisuue />
        <BankOfCardIssue />
        <CreateDate>2014-09-22T19:14:35</CreateDate>
        <CardRiskNoPreCode>E7FAA18B61E1F4D8F09A3BAE0F80F5A9</CardRiskNoPreCode>
        <CardRiskNoLastCode>5227FA9A19DCE7BA113F50A405DCAF09</CardRiskNoLastCode>
        <PhoneNo>15055555555</PhoneNo>
        <IsVerifyNoEmpty>F</IsVerifyNoEmpty>
        </CreditCardInfoResponseItem>
        <CreditCardInfoResponseItem>
        <CardInfoId>29280194</CardInfoId>
        <CreditCardType>9</CreditCardType>
        <CardTypeName>境外发行信用卡 -- 大来(Diners Club)</CardTypeName>
        <CreditCardNumber>CTRP71C0C8F3274701B0E06529EBCFE99879</CreditCardNumber>
        <CCardNoCode>1DB3AB91361409B49FB92F470586279B</CCardNoCode>
        <CValidityCode>6C401AA1FFA5C0F4C6BF4766DDB8F3EC</CValidityCode>
        <CardBin>300000</CardBin>
        <Validity>CTRP88D82DF4CD1EC9C0EEA57B73D5C389C2</Validity>
        <CardHolder>ZHICHNG</CardHolder>
        <IdCardType>0</IdCardType>
        <IdNumber />
        <VerifyNo />
        <CurrencyType>U</CurrencyType>
        <VM_Type>U</VM_Type>
        <IsForeignCard>T</IsForeignCard>
        <LocalCardType>U</LocalCardType>
        <AgreementCode />
        <Nationality>  </Nationality>
        <StateName />
        <BillingAddress />
        <ZipCode />
        <Nationalityofisuue>  </Nationalityofisuue>
        <BankOfCardIssue />
        <CreateDate>2014-09-28T10:19:40</CreateDate>
        <CardRiskNoPreCode>759C4D33228B3FD088E39922D8AC05E1</CardRiskNoPreCode>
        <CardRiskNoLastCode>95B09698FDA1F64AF16708FFB859EAB9</CardRiskNoLastCode>
        <PhoneNo />
        <IsVerifyNoEmpty>F</IsVerifyNoEmpty>
        </CreditCardInfoResponseItem>
        <CreditCardInfoResponseItem>
        <CardInfoId>29546748</CardInfoId>
        <CreditCardType>11</CreditCardType>
        <CardTypeName>中国招商银行 -- 信用卡</CardTypeName>
        <CreditCardNumber>CTRPA13F75FE8D370C6862BEB376016607BB</CreditCardNumber>
        <CCardNoCode>6351A72CAA94E42ECFE22E1E2EF1C912</CCardNoCode>
        <CValidityCode>96AB5CC2F028CE5A42CB0E728458B2DE</CValidityCode>
        <CardBin>439225</CardBin>
        <Validity>CTRPD7CC4B9C6A3CE27A0805E0503D84AAAF</Validity>
        <CardHolder />
        <IdCardType>0</IdCardType>
        <IdNumber />
        <VerifyNo>CTRP3A14C957237A82E9AF1D08DE17BB50E0</VerifyNo>
        <CurrencyType>U</CurrencyType>
        <VM_Type>U</VM_Type>
        <IsForeignCard>F</IsForeignCard>
        <LocalCardType>U</LocalCardType>
        <AgreementCode />
        <Nationality>  </Nationality>
        <StateName />
        <BillingAddress />
        <ZipCode />
        <Nationalityofisuue>  </Nationalityofisuue>
        <BankOfCardIssue />
        <CreateDate>2014-11-06T11:30:23</CreateDate>
        <CardRiskNoPreCode>0AA7620D235C3D5D4E9A8273C72E87F3</CardRiskNoPreCode>
        <CardRiskNoLastCode>29549A71A57F587D88209B9C1F1B7999</CardRiskNoLastCode>
        <PhoneNo />
        <IsVerifyNoEmpty>F</IsVerifyNoEmpty>
        </CreditCardInfoResponseItem>
        <CreditCardInfoResponseItem>
        <CardInfoId>29548218</CardInfoId>
        <CreditCardType>564</CreditCardType>
        <CardTypeName>银联在线（兴业银行）</CardTypeName>
        <CreditCardNumber>CTRPC9BE5009218564792AC282AC5E0D71B6</CreditCardNumber>
        <CCardNoCode>9F5F6EE25FA88D4456417F98C807925C</CCardNoCode>
        <CValidityCode>BE67CBB10E70F06468DD9C0AB46AA2AF</CValidityCode>
        <CardBin>622922</CardBin>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <CardHolder>默哀</CardHolder>
        <IdCardType>0</IdCardType>
        <IdNumber />
        <VerifyNo>CTRP0F553EDD7995F54E8DEC7A4740EAC17F</VerifyNo>
        <CurrencyType>U</CurrencyType>
        <VM_Type>U</VM_Type>
        <IsForeignCard>F</IsForeignCard>
        <LocalCardType>U</LocalCardType>
        <AgreementCode />
        <Nationality>  </Nationality>
        <StateName />
        <BillingAddress />
        <ZipCode />
        <Nationalityofisuue>  </Nationalityofisuue>
        <BankOfCardIssue />
        <CreateDate>2014-11-07T18:05:42</CreateDate>
        <CardRiskNoPreCode>F43E50D6E0FD2B7D7B6E8230016EFB4C</CardRiskNoPreCode>
        <CardRiskNoLastCode>A591024321C5E2BDBD23ED35F0574DDE</CardRiskNoLastCode>
        <PhoneNo>13811118888</PhoneNo>
        <IsVerifyNoEmpty>T</IsVerifyNoEmpty>
        </CreditCardInfoResponseItem>
        <CreditCardInfoResponseItem>
        <CardInfoId>29548438</CardInfoId>
        <CreditCardType>2</CreditCardType>
        <CardTypeName>中国工商银行 -- 牡丹卡</CardTypeName>
        <CreditCardNumber>CTRP97D2043F59E462D9EF4879185DB9F412</CreditCardNumber>
        <CCardNoCode>F3C393B0C534635D63A0DDE11F94354C</CCardNoCode>
        <CValidityCode>BE67CBB10E70F06468DD9C0AB46AA2AF</CValidityCode>
        <CardBin>402791</CardBin>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <CardHolder>maomao</CardHolder>
        <IdCardType>1</IdCardType>
        <IdNumber>341181198501194237</IdNumber>
        <VerifyNo>CTRP0F553EDD7995F54E8DEC7A4740EAC17F</VerifyNo>
        <CurrencyType>U</CurrencyType>
        <VM_Type>U</VM_Type>
        <IsForeignCard>F</IsForeignCard>
        <LocalCardType>U</LocalCardType>
        <AgreementCode />
        <Nationality>  </Nationality>
        <StateName />
        <BillingAddress />
        <ZipCode />
        <Nationalityofisuue>  </Nationalityofisuue>
        <BankOfCardIssue />
        <CreateDate>2014-11-10T10:57:59</CreateDate>
        <CardRiskNoPreCode>6861032CA95668905302922371BB2E10</CardRiskNoPreCode>
        <CardRiskNoLastCode>25BBDCD06C32D477F7FA1C3E4A91B032</CardRiskNoLastCode>
        <PhoneNo />
        <IsVerifyNoEmpty>T</IsVerifyNoEmpty>
        </CreditCardInfoResponseItem>
        <CreditCardInfoResponseItem>
        <CardInfoId>30026224</CardInfoId>
        <CreditCardType>1</CreditCardType>
        <CardTypeName>中国银行 -- 长城卡</CardTypeName>
        <CreditCardNumber>CTRP939AB78F700DDBADE846B5D4D14AE163</CreditCardNumber>
        <CCardNoCode>0079A7A845EB03DA9C2AE23BBD02ACC5</CCardNoCode>
        <CValidityCode>117AE08A6CF4E284F9C05EC8B7173A28</CValidityCode>
        <CardBin>622346</CardBin>
        <Validity>CTRP98D37F84AA7563C7816C9A841325C95D</Validity>
        <CardHolder />
        <IdCardType>0</IdCardType>
        <IdNumber />
        <VerifyNo>CTRP4ECD865D22D99C71F9A040D602E64E23</VerifyNo>
        <CurrencyType>U</CurrencyType>
        <VM_Type>U</VM_Type>
        <IsForeignCard>F</IsForeignCard>
        <LocalCardType>U</LocalCardType>
        <AgreementCode />
        <Nationality />
        <StateName />
        <BillingAddress />
        <ZipCode />
        <Nationalityofisuue />
        <BankOfCardIssue />
        <CreateDate>2014-12-02T14:29:02</CreateDate>
        <CardRiskNoPreCode>D7237609858FFC94313D6CBC043BE10F</CardRiskNoPreCode>
        <CardRiskNoLastCode>FBA9D88164F3E2D9109EE770223212A0</CardRiskNoLastCode>
        <PhoneNo />
        <IsVerifyNoEmpty>F</IsVerifyNoEmpty>
        </CreditCardInfoResponseItem>
        <CreditCardInfoResponseItem>
        <CardInfoId>30026916</CardInfoId>
        <CreditCardType>1137</CreditCardType>
        <CardTypeName>储蓄卡快捷（招商银行）</CardTypeName>
        <CreditCardNumber>CTRPD1175FE13E48ECE7640F91C3E7C1CACD</CreditCardNumber>
        <CCardNoCode>84BD230418094B82D6CF355AC73F7AB2</CCardNoCode>
        <CValidityCode>EC7D9D60222157632EF18B0B5EE99F38</CValidityCode>
        <CardBin>622588</CardBin>
        <Validity>CTRP3C1A3ECFC56F7B64F8890ACF80497BC5</Validity>
        <CardHolder>毛毛</CardHolder>
        <IdCardType>1</IdCardType>
        <IdNumber>341181198501194237</IdNumber>
        <VerifyNo>CTRP0F553EDD7995F54E8DEC7A4740EAC17F</VerifyNo>
        <CurrencyType>U</CurrencyType>
        <VM_Type>U</VM_Type>
        <IsForeignCard>F</IsForeignCard>
        <LocalCardType>U</LocalCardType>
        <AgreementCode />
        <Nationality>  </Nationality>
        <StateName />
        <BillingAddress />
        <ZipCode />
        <Nationalityofisuue>  </Nationalityofisuue>
        <BankOfCardIssue />
        <CreateDate>2014-12-03T11:00:19</CreateDate>
        <CardRiskNoPreCode>5AEC098A042522AC9A0B4AEF9168B1C5</CardRiskNoPreCode>
        <CardRiskNoLastCode>44089D5F715BC4112AD95576555D0F4E</CardRiskNoLastCode>
        <PhoneNo>18155454545</PhoneNo>
        <IsVerifyNoEmpty>T</IsVerifyNoEmpty>
        </CreditCardInfoResponseItem>
        <CreditCardInfoResponseItem>
        <CardInfoId>30026927</CardInfoId>
        <CreditCardType>16</CreditCardType>
        <CardTypeName>中国民生银行 -- 信用卡</CardTypeName>
        <CreditCardNumber>CTRPD6E8B198A56BCC76FDD2BFF56BAF3B81</CreditCardNumber>
        <CCardNoCode>483089FAE73DB6CB4DCC22EA844DE01C</CCardNoCode>
        <CValidityCode>D2D37B889E1A2908EEB7694DBD43C57D</CValidityCode>
        <CardBin>407405</CardBin>
        <Validity>CTRP09369F80BB5CBCA3320A2FB847387DCA</Validity>
        <CardHolder />
        <IdCardType>0</IdCardType>
        <IdNumber />
        <VerifyNo>CTRP90A245F9306F2B41F22842FBBC41FE29</VerifyNo>
        <CurrencyType>U</CurrencyType>
        <VM_Type>U</VM_Type>
        <IsForeignCard>F</IsForeignCard>
        <LocalCardType>U</LocalCardType>
        <AgreementCode />
        <Nationality />
        <StateName />
        <BillingAddress />
        <ZipCode />
        <Nationalityofisuue />
        <BankOfCardIssue />
        <CreateDate>2014-12-03T11:05:03</CreateDate>
        <CardRiskNoPreCode>089F21D6F1E32287C02CB6E6FBF6D22C</CardRiskNoPreCode>
        <CardRiskNoLastCode>926ABAE84A4BD33C834BC6B981B8CF30</CardRiskNoLastCode>
        <PhoneNo />
        <IsVerifyNoEmpty>F</IsVerifyNoEmpty>
        </CreditCardInfoResponseItem>
        <CreditCardInfoResponseItem>
        <CardInfoId>30031180</CardInfoId>
        <CreditCardType>2</CreditCardType>
        <CardTypeName>中国工商银行 -- 牡丹卡</CardTypeName>
        <CreditCardNumber>CTRPD12024D349886E5F2599D11B7CB9272B</CreditCardNumber>
        <CCardNoCode>550ED66581D5A35082DA1F83F01920E1</CCardNoCode>
        <CValidityCode>BE67CBB10E70F06468DD9C0AB46AA2AF</CValidityCode>
        <CardBin>427020</CardBin>
        <Validity>CTRP23923EC0E89E068F0FCB475898BBA2B7</Validity>
        <CardHolder>玩家</CardHolder>
        <IdCardType>2</IdCardType>
        <IdNumber>Cd12345</IdNumber>
        <VerifyNo>CTRP0F553EDD7995F54E8DEC7A4740EAC17F</VerifyNo>
        <CurrencyType>U</CurrencyType>
        <VM_Type>U</VM_Type>
        <IsForeignCard>F</IsForeignCard>
        <LocalCardType>U</LocalCardType>
        <AgreementCode />
        <Nationality>  </Nationality>
        <StateName />
        <BillingAddress />
        <ZipCode />
        <Nationalityofisuue>  </Nationalityofisuue>
        <BankOfCardIssue />
        <CreateDate>2014-12-09T21:04:34</CreateDate>
        <CardRiskNoPreCode>EDD6FFFCAFE4F394FF96E149C19A429A</CardRiskNoPreCode>
        <CardRiskNoLastCode>5ACDC9CA5D99AE66AFDFE1EEA0E3B26B</CardRiskNoLastCode>
        <PhoneNo>15954444444</PhoneNo>
        <IsVerifyNoEmpty>T</IsVerifyNoEmpty>
        </CreditCardInfoResponseItem>
        <CreditCardInfoResponseItem>
        <CardInfoId>30032988</CardInfoId>
        <CreditCardType>11</CreditCardType>
        <CardTypeName>中国招商银行 -- 信用卡</CardTypeName>
        <CreditCardNumber>CTRP5EDAF1582F6798C118968C0E582314D5</CreditCardNumber>
        <CCardNoCode>FD15FC4A672A81BE4DB3A6300EF57025</CCardNoCode>
        <CValidityCode>13174A5AE720F555C82452F457F25F39</CValidityCode>
        <CardBin>439226</CardBin>
        <Validity>CTRPFA29602DF1D42BC43C68506D59BDD42B</Validity>
        <CardHolder>毛毛</CardHolder>
        <IdCardType>1</IdCardType>
        <IdNumber>341181198501194237</IdNumber>
        <VerifyNo>CTRP0F4D9964918A2623148C2C5B158D9FC0</VerifyNo>
        <CurrencyType>U</CurrencyType>
        <VM_Type>U</VM_Type>
        <IsForeignCard>F</IsForeignCard>
        <LocalCardType>U</LocalCardType>
        <AgreementCode />
        <Nationality>  </Nationality>
        <StateName />
        <BillingAddress />
        <ZipCode />
        <Nationalityofisuue>  </Nationalityofisuue>
        <BankOfCardIssue />
        <CreateDate>2014-12-11T21:28:26</CreateDate>
        <CardRiskNoPreCode>51946DB4D249E6BDB61AFD221BD8075F</CardRiskNoPreCode>
        <CardRiskNoLastCode>E36E62F84744EA6916927027C9D651AD</CardRiskNoLastCode>
        <PhoneNo>13811118888</PhoneNo>
        <IsVerifyNoEmpty>F</IsVerifyNoEmpty>
        </CreditCardInfoResponseItem>
        </CreditCardItems>
        </GetCreditCardInfoResponse>
        </Response>";

            string req6 = @"<?xml version='1.0'?>
        <Request>
        <Header UserID='340101' RequestID='1cf0e963-3a7e-41ed-898d-a0ffdc13a06c' RequestType='Payment.Base.MerchantService.QueryCustomeDeductPayWay' ClientIP='172.16.146.78' AsyncRequest='false' Timeout='0' MessagePriority='3' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fws' UseMemoryQ='false' />
        <QueryCustomeDeductPayWayRequest>
        <Uid>13811118888</Uid>
        </QueryCustomeDeductPayWayRequest>
        </Request>";
            string res6 = @"<?xml version='1.0'?>
        <Response>
        <Header ServerIP='10.2.254.17' ShouldRecordPerformanceTime='false' UserID='340101' RequestID='1cf0e963-3a7e-41ed-898d-a0ffdc13a06c' ResultCode='Success' ResultNo='0' ResultMsg='成功' AssemblyVersion='2.8.0.0' RequestBodySize='0' SerializeMode='Xml' RouteStep='1' Environment='fws' />
        <QueryCustomeDeductPayWayResponse>
        <PayWayItems>
        <PayWayItem>
        <CatalogCode>CreditCard</CatalogCode>
        <PaymentWayID>CC_CMB</PaymentWayID>
        <Pre6Last2Code>439226|40</Pre6Last2Code>
        <CardChannel>
        <ChannelType>7</ChannelType>
        <ChannelType>11</ChannelType>
        <ChannelType>558</ChannelType>
        </CardChannel>
        </PayWayItem>
        </PayWayItems>
        </QueryCustomeDeductPayWayResponse>
        </Response>";

            removeUnNeededTag(reqXml);

            var res = string.Empty;
            xmlPattern.LoadXml(req1);
            removeUnNeededTag(xmlPattern);
            if (xmlPattern.InnerXml.Equals(reqXml.InnerXml))
                res = res1;
            xmlPattern.LoadXml(req2);
            removeUnNeededTag(xmlPattern);
            if (xmlPattern.InnerXml.Equals(reqXml.InnerXml))
                res = res2;
            xmlPattern.LoadXml(req3);
            removeUnNeededTag(xmlPattern);
            if (xmlPattern.InnerXml.Equals(reqXml.InnerXml))
                res = res3;
            xmlPattern.LoadXml(req4);
            removeUnNeededTag(xmlPattern);
            if (xmlPattern.InnerXml.Equals(reqXml.InnerXml))
                res = res4;
            xmlPattern.LoadXml(req5);
            removeUnNeededTag(xmlPattern);
            if (xmlPattern.InnerXml.Equals(reqXml.InnerXml))
                res = res5;
            xmlPattern.LoadXml(req6);
            removeUnNeededTag(xmlPattern);
            if (xmlPattern.InnerXml.Equals(reqXml.InnerXml))
                res = res6;

            return res;
        }

        private static void removeUnNeededTag(XmlDocument reqXml)
        {
            var xmlReqTmp = reqXml.SelectSingleNode("Request/Header") as XmlElement;
            if (xmlReqTmp != null)
                xmlReqTmp.RemoveAttribute("ClientIP");

            xmlReqTmp = reqXml.SelectSingleNode("Request/Header") as XmlElement;
            if (xmlReqTmp != null)
                xmlReqTmp.RemoveAttribute("RequestID");
        }
    }
}