# Esnya SF Addons

[SaccFlightAndVehicles](https://github.com/Sacchan-VRC/SaccFlightAndVehicles)用のアドオンとユーティリティです。

---

## 必要要件
- VRChat Creator Companion 経由でインストールする [**UdonSharp 1.x**](https://github.com/vrchat-community/UdonSharp)  
- [**SaccFlightAndVehicles 1.63**](https://github.com/Sacchan-VRC/SaccFlightAndVehicles/tree/1.63)  
- [UdonToolkit](https://github.com/orels1/UdonToolkit/)  
- [InariUdon](https://github.com/esnya/InariUdon/)  

---

## インストール手順
1. 必要要件をすべてインストールしてください。  
2. Unityの「Package Manager」ウィンドウを開きます。  

![image](https://user-images.githubusercontent.com/2088693/217635380-a175d873-bf18-412e-bc74-2c7df1fe9b17.png)

3. 「Add package from git URL」をクリックします。  

![image](https://user-images.githubusercontent.com/2088693/217635570-44827dc0-cb20-4e4d-a4d3-7ef1e1041d6f.png)

4. 次のURLを入力し、「Add」をクリックします。  
   - 通常版: `git+https://github.com/esnya/EsnyaSFAddons.git?path=Packages/com.nekometer.esnya.esnya-sf-addons`  
   - ベータ版: `git+https://github.com/esnya/EsnyaSFAddons.git?path=Packages/com.nekometer.esnya.esnya-sf-addons#beta`

![image](https://user-images.githubusercontent.com/2088693/217635892-7a612e44-f09f-452c-9741-d981542fc412.png)

---

## 機能一覧
### カスタムインスペクター / ギズモ  
#### **SaccEntityEditor**  
![image](https://user-images.githubusercontent.com/2088693/148947722-70cbda93-6721-4722-b0c7-527bd5a32c38.png)  

**SaccEntity** 用のカスタムインスペクターです。検証機能や自動入力ボタンを備えています。  

![image](https://user-images.githubusercontent.com/2088693/148947839-bf8f137f-38dd-4faf-8d96-b9fffd6b6c99.png)  

以下のDFUNCやExtensionの参照を自動検索して入力します。また、以下の指定された名前のGameObjectも検索します：
- InVehicleOnly  
- HoldingOnly  
- CenterOfMass  
- SwitchFunctionSound  
- DisabledAfter10Seconds  

![image](https://user-images.githubusercontent.com/2088693/148948264-03c1996c-7864-45a8-bc33-305bf76e154e.png)  

**StickDisplay** のMFDアイテムを自動的に整列します。
- 親GameObjectの名前は「StickDisplayL」または「StickDisplayR」である必要があります。Templateフォルダ内のプレハブの使用を推奨します。
- 各アイテムの名前は「MFD_」で始まる必要があります。

#### **SAV_KeyboardControlsEditor**  
![image](https://user-images.githubusercontent.com/2088693/142752033-5c491832-0b28-4bf2-9317-dae26314fe8e.png)  

**SAV_KeyboardControls** 用のカスタムインスペクターで、自動入力ボタンを備えています。

#### **SVGizmoDrawer**  
![image](https://user-images.githubusercontent.com/2088693/142752067-16101550-75a2-4800-bca4-51fd82704d39.png)  

**SaccVehicleSeat** の **TargetEyeHeight** や **FloatScript** の **FloatPoints** にギズモを追加します。

---

### Udonスクリプト
#### **SFRuntimeSetup**  
![image](https://user-images.githubusercontent.com/2088693/142752139-16044ef1-ca37-40ce-b437-f3d3f4cec1c8.png)  

ワールドに設定されたパラメータをPrefabを上書きせずに、ワールド読み込み時にすべての車両に適用します。

---

## SFUdonChips

**SaccFlight** を **UdonChips** と統合するアドオンです。

#### **SAV_UdonChips**  
![image](https://user-images.githubusercontent.com/2088693/142752173-58ba708d-1f6f-4f80-9457-b394f02baa47.png)

---

### SFUdonChips の必要要件
- [UdonChips-fork](https://github.com/esnya/UdonChips-fork)

---

### インストール手順
1. 必要要件をすべてインストールしてください。  
2. Unityの「Package Manager」ウィンドウを開きます。  
3. 「Add package from git URL」をクリックします。  
4. 次のURLを入力し、「Add」をクリックします：  
   `git+https://github.com/esnya/EsnyaSFAddons.git?path=Packages/com.nekometer.esnya.esnya-sf-addons-ucs`  
