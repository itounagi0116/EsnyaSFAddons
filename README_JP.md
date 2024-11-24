# Esnya SF Addons  

![ライセンスバッジ](https://img.shields.io/badge/ライセンス-MIT-007EC6)

[補足](https://github.com/itounagi0116/EsnyaSFAddons/blob/master/%E8%A3%9C%E8%B6%B3.md)

[SaccFlightAndVehicles](https://github.com/Sacchan-VRC/SaccFlightAndVehicles)用のアドオンおよびユーティリティです。  

---

## **必要要件**  
- **UdonSharp 1.x**（VRChat Creator Companion経由でインストール）  
- **SaccFlightAndVehicles 1.63**  
- **[InariUdon](https://github.com/esnya/InariUdon/)**  

---

## **インストール方法**  

1. 必要な要件をすべてインストールします。  
2. **Package Manager** ウィンドウを開きます。  

![Package Managerを開く](https://user-images.githubusercontent.com/2088693/217635380-a175d873-bf18-412e-bc74-2c7df1fe9b17.png)  

3. 「+」ボタンをクリックし、**`Add package from git URL`** を選択します。  

![URL追加ボタン](https://user-images.githubusercontent.com/2088693/217635570-44827dc0-cb20-4e4d-a4d3-7ef1e1041d6f.png)  

4. 次のURLを入力し、「Add」ボタンをクリックします。  
   - **安定版リリース**:  
     `git+https://github.com/esnya/EsnyaSFAddons.git?path=Packages/com.nekometer.esnya.esnya-sf-addons`  
   - **ベータ版リリース**:  
     `git+https://github.com/esnya/EsnyaSFAddons.git?path=Packages/com.nekometer.esnya.esnya-sf-addons#beta`  

![URL入力例](https://user-images.githubusercontent.com/2088693/217635892-7a612e44-f09f-452c-9741-d981542fc412.png)  

---

## **機能一覧**  

### **カスタムインスペクター / ギズモ**  

#### **SaccEntityEditor**  
![SaccEntityEditor](https://user-images.githubusercontent.com/2088693/148947722-70cbda93-6721-4722-b0c7-527bd5a32c38.png)  
SaccEntity用のカスタムインスペクターで、バリデーションや自動入力ボタンを提供します。  

![自動入力機能](https://user-images.githubusercontent.com/2088693/148947839-bf8f137f-38dd-4faf-8d96-b9fffd6b6c99.png)  
DFUNCや拡張機能の参照を自動検索・入力します。また、以下の名前が付いたGameObjectも自動的に検出します:  
- InVehicleOnly  
- HoldingOnly  
- CenterOfMass  
- SwitchFunctionSound  
- DisabledAfter10Seconds  

![StickDisplay配置](https://user-images.githubusercontent.com/2088693/148948264-03c1996c-7864-45a8-bc33-305bf76e154e.png)  
StickDisplayのMFDアイテムを自動整列します。  
- 親のGameObject名は「StickDisplayL」または「StickDisplayR」にする必要があります（テンプレートフォルダのプレハブを推奨）。  
- 各アイテムの名前は「MFD_」で始める必要があります。  

#### **SAV_KeyboardControlsEditor**  
![SAV_KeyboardControlsEditor](https://user-images.githubusercontent.com/2088693/142752033-5c491832-0b28-4bf2-9317-dae26314fe8e.png)  
SAV_KeyboardControls用のカスタムインスペクターで、自動入力ボタンを提供します。  

#### **SVGizmoDrawer**  
![SVGizmoDrawer](https://user-images.githubusercontent.com/2088693/142752067-16101550-75a2-4800-bca4-51fd82704d39.png)  
SaccVehicleSeatのTargetEyeHeightやFloatScriptのFloatPointsにギズモを追加します。  

---

### **Udon関連機能**  

#### **SFRuntimeSetup**  
![SFRuntimeSetup](https://user-images.githubusercontent.com/2088693/142752139-16044ef1-ca37-40ce-b437-f3d3f4cec1c8.png)  
ワールド読み込み時に、ワールドで指定されたパラメーターをすべての乗り物に適用します（プレハブのオーバーライドなし）。  

---

## **SFUdonChips**  

UdonChipsとSaccFlightを統合します。  

#### **SAV_UdonChips**  
![SAV_UdonChips](https://user-images.githubusercontent.com/2088693/142752173-58ba708d-1f6f-4f80-9457-b394f02baa47.png)  

---

### **SFUdonChipsの必要要件**  
- **[UdonChips-fork](https://github.com/esnya/UdonChips-fork)**  

---

### **SFUdonChipsのインストール方法**  

1. 必要な要件をすべてインストールします。  
2. **Package Manager** ウィンドウを開きます。  
3. 「+」ボタンをクリックし、**`Add package from git URL`** を選択します。  
4. 次のURLを入力し、「Add」ボタンをクリックします:  
   - **安定版リリース**:  
     `git+https://github.com/esnya/EsnyaSFAddons.git?path=Packages/com.nekometer.esnya.esnya-sf-addons-ucs`  
   - **ベータ版リリース**:  
     `git+https://github.com/esnya/EsnyaSFAddons.git?path=Packages/com.nekometer.esnya.esnya-sf-addons-ucs#beta`  