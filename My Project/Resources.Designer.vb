﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Hana_Feeder_Management.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Location:.
        '''</summary>
        Friend ReadOnly Property Lab_DefaultInvLocation() As String
            Get
                Return ResourceManager.GetString("Lab_DefaultInvLocation", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to INV# .
        '''</summary>
        Friend ReadOnly Property Lab_DefaultInvNo() As String
            Get
                Return ResourceManager.GetString("Lab_DefaultInvNo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to INV #.
        '''</summary>
        Friend ReadOnly Property Lab_InvNo() As String
            Get
                Return ResourceManager.GetString("Lab_InvNo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ระบบกำลังโหลดข้อมูลของ Invoice .
        '''</summary>
        Friend ReadOnly Property Lab_InvoiceLoading() As String
            Get
                Return ResourceManager.GetString("Lab_InvoiceLoading", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Invoice Saved for Printing.
        '''</summary>
        Friend ReadOnly Property Lab_InvoiceSaveDone() As String
            Get
                Return ResourceManager.GetString("Lab_InvoiceSaveDone", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to New Invoice Creating.
        '''</summary>
        Friend ReadOnly Property Lab_NewInvoiceCreate() As String
            Get
                Return ResourceManager.GetString("Lab_NewInvoiceCreate", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to PALLET #.
        '''</summary>
        Friend ReadOnly Property Lab_PalletNo() As String
            Get
                Return ResourceManager.GetString("Lab_PalletNo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Remain Carton:.
        '''</summary>
        Friend ReadOnly Property Lab_RemainCtn() As String
            Get
                Return ResourceManager.GetString("Lab_RemainCtn", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Total Invoice :.
        '''</summary>
        Friend ReadOnly Property Lab_TotalInvoice() As String
            Get
                Return ResourceManager.GetString("Lab_TotalInvoice", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Total Carton : .
        '''</summary>
        Friend ReadOnly Property Lab_TotalOuter() As String
            Get
                Return ResourceManager.GetString("Lab_TotalOuter", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Total Pallet : .
        '''</summary>
        Friend ReadOnly Property Lab_TotalPallet() As String
            Get
                Return ResourceManager.GetString("Lab_TotalPallet", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ระบบกำลังประมวลผลการทำงานเบื้องหลัง กรุณารอสักครู่ก่อนลองอีกครั้ง.
        '''</summary>
        Friend ReadOnly Property Warn_BgwProcessingBlock() As String
            Get
                Return ResourceManager.GetString("Warn_BgwProcessingBlock", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ไม่สามารถ Print ได้เนื่องจากเกิดปัญหาขณะเตรียมไฟล์ข้อมูล BarTender.
        '''</summary>
        Friend ReadOnly Property Warn_BtwDBTxtFileError() As String
            Get
                Return ResourceManager.GetString("Warn_BtwDBTxtFileError", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Carton หมายเลขนี้ ได้ถูกสแกนเข้ากับ Pallet แล้ว.
        '''</summary>
        Friend ReadOnly Property Warn_CartonAlreadyScanPallet() As String
            Get
                Return ResourceManager.GetString("Warn_CartonAlreadyScanPallet", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ระบบไม่อนุญาตให้ลบ Carton ออกจาก Pallet ภายใต้สถานะนี้.
        '''</summary>
        Friend ReadOnly Property Warn_CartonDeleteNotAllow() As String
            Get
                Return ResourceManager.GetString("Warn_CartonDeleteNotAllow", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to MSS User ของท่านไม่ได้รับอนุญาตการ Re-print.
        '''</summary>
        Friend ReadOnly Property Warn_CartonIDAlreadyPrinted() As String
            Get
                Return ResourceManager.GetString("Warn_CartonIDAlreadyPrinted", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Carton นี้ไม่อยู่ในชุด Invoice ปัจจุบัน กรุณาตรวจสอบ.
        '''</summary>
        Friend ReadOnly Property Warn_CartonNotExistConfirmLoad() As String
            Get
                Return ResourceManager.GetString("Warn_CartonNotExistConfirmLoad", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to การสแกน Carton ID ไม่ได้ถูกรองรับในขั้นตอนนี้ กรุณาตรวจสอบ.
        '''</summary>
        Friend ReadOnly Property Warn_CartonScanNotSupport() As String
            Get
                Return ResourceManager.GetString("Warn_CartonScanNotSupport", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Catch Error กรุณาติดต่อ Valor #420(LPN1).
        '''</summary>
        Friend ReadOnly Property Warn_CatchErrorContactValor() As String
            Get
                Return ResourceManager.GetString("Warn_CatchErrorContactValor", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ยืนยันดำเนินการ Close Pallet ที่เลือก ?.
        '''</summary>
        Friend ReadOnly Property Warn_ClosePalletConfirm() As String
            Get
                Return ResourceManager.GetString("Warn_ClosePalletConfirm", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ไม่สามารถปิด Pallet ได้ เนื่องจากไม่มีข้อมูล Carton.
        '''</summary>
        Friend ReadOnly Property Warn_ClosePalletNotAllowNoCarton() As String
            Get
                Return ResourceManager.GetString("Warn_ClosePalletNotAllowNoCarton", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ข้อมูล Carton ได้ถูก Print ไปแล้ว ยืนยันการเริ่มต้นใหม่หรือไม่ ?.
        '''</summary>
        Friend ReadOnly Property Warn_ConfirmBeforeResetPrinted() As String
            Get
                Return ResourceManager.GetString("Warn_ConfirmBeforeResetPrinted", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ยืนยันการบันทึกข้อมูลสำหรับ Invoice.
        '''</summary>
        Friend ReadOnly Property Warn_ConfirmInputBoxInfo() As String
            Get
                Return ResourceManager.GetString("Warn_ConfirmInputBoxInfo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to การ Logout จะยกเลิกการทำงานทั้งหมด ยืนยันการดำเนินการต่อ ?.
        '''</summary>
        Friend ReadOnly Property Warn_ConfirmLogout() As String
            Get
                Return ResourceManager.GetString("Warn_ConfirmLogout", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ยืนยันการPrint สำหรับทุกหมายเลข Carton ID หรือไม่ ?.
        '''</summary>
        Friend ReadOnly Property Warn_ConfirmPrintAllBox() As String
            Get
                Return ResourceManager.GetString("Warn_ConfirmPrintAllBox", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ยืนยันการ Print สำหรับ Carton ID ที่เลือกทั้งหมด .
        '''</summary>
        Friend ReadOnly Property Warn_ConfirmPrintBoxSelect() As String
            Get
                Return ResourceManager.GetString("Warn_ConfirmPrintBoxSelect", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ยืนยันการ Print สำหรับ Pallet ID ?.
        '''</summary>
        Friend ReadOnly Property Warn_ConfirmPrintPalletID() As String
            Get
                Return ResourceManager.GetString("Warn_ConfirmPrintPalletID", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ยืนยันการบันทึกข้อมูล New Pallet ?.
        '''</summary>
        Friend ReadOnly Property Warn_ConfirmSaveNewPallet() As String
            Get
                Return ResourceManager.GetString("Warn_ConfirmSaveNewPallet", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to DB Process Error กรุณาติดต่อ Valor#420(LPN1).
        '''</summary>
        Friend ReadOnly Property Warn_DBCatchError() As String
            Get
                Return ResourceManager.GetString("Warn_DBCatchError", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ยืนยันการลบข้อมูล Carton ID ทั้งหมดใน Pallet.
        '''</summary>
        Friend ReadOnly Property Warn_DeleteAllCartonConfirm() As String
            Get
                Return ResourceManager.GetString("Warn_DeleteAllCartonConfirm", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ไม่พบข้อมูล Carton ID สำหรับการลบ กรุณาตรวจสอบ.
        '''</summary>
        Friend ReadOnly Property Warn_DeleteCartonMustSelected() As String
            Get
                Return ResourceManager.GetString("Warn_DeleteCartonMustSelected", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to รูปแบบของข้อความ Scan นี้ไม่รองรับในระบบ กรุณาตรวจสอบ.
        '''</summary>
        Friend ReadOnly Property Warn_FormatScanNotMatch() As String
            Get
                Return ResourceManager.GetString("Warn_FormatScanNotMatch", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to กรุณาระบุข้อมูลเป็นตัวเลขจำนวนเต็มเท่านั้น.
        '''</summary>
        Friend ReadOnly Property Warn_IntegerInputOnly() As String
            Get
                Return ResourceManager.GetString("Warn_IntegerInputOnly", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Invoice ชุดนี้ยังไม่ได้รับการสแกนจับคู่ Outer Box กรุณาตรวจสอบ.
        '''</summary>
        Friend ReadOnly Property Warn_InvCartonNotMatch() As String
            Get
                Return ResourceManager.GetString("Warn_InvCartonNotMatch", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ระบบไม่สามารถตรวจสอบข้อมูล Invoice ได้ กรุณาติดต่อ Valor#420(LPN1).
        '''</summary>
        Friend ReadOnly Property Warn_InvCheckingError() As String
            Get
                Return ResourceManager.GetString("Warn_InvCheckingError", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ระบบยังไม่รองรับการ Reset ของ Invoice สถานะ Done กรุณาติดต่อ Valor#420(LPN1).
        '''</summary>
        Friend ReadOnly Property Warn_InvDoneNotAllowReset() As String
            Get
                Return ResourceManager.GetString("Warn_InvDoneNotAllowReset", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ไม่พบข้อมูลของ Invoice สำหรับการทำ Pallet Label.
        '''</summary>
        Friend ReadOnly Property Warn_InvForPalletNotFound() As String
            Get
                Return ResourceManager.GetString("Warn_InvForPalletNotFound", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to กรุณาสแกน Invoice ก่อนดำเนินการต่อ.
        '''</summary>
        Friend ReadOnly Property Warn_InvNeedToScanBefore() As String
            Get
                Return ResourceManager.GetString("Warn_InvNeedToScanBefore", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Invoice สถานะ Save ไม่สามารถแก้ไขได้ กรุณา Reset ก่อนดำเนินการต่อ.
        '''</summary>
        Friend ReadOnly Property Warn_InvPrintDoneNeedCancel() As String
            Get
                Return ResourceManager.GetString("Warn_InvPrintDoneNeedCancel", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Invoice ได้ถูกสแกนแล้ว กรุณาดำเนินการต่อ.
        '''</summary>
        Friend ReadOnly Property Warn_InvScannedToContinue() As String
            Get
                Return ResourceManager.GetString("Warn_InvScannedToContinue", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ระบบกำลังโหลดส่วนเสริม Bartender หากมีหน้าต่างใดๆ ปรากฏ กรุณากด OK.
        '''</summary>
        Friend ReadOnly Property Warn_LoadBtwProcess() As String
            Get
                Return ResourceManager.GetString("Warn_LoadBtwProcess", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to กรุณา Login MSS User ก่อนดำเนินการต่อ.
        '''</summary>
        Friend ReadOnly Property Warn_LoginBeforeScan() As String
            Get
                Return ResourceManager.GetString("Warn_LoginBeforeScan", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to จำนวน Carton ทั้งหมดเกินกว่าที่ระบบอนุญาตให้ Print ในหนึ่งครั้ง.
        '''</summary>
        Friend ReadOnly Property Warn_MaxCartonPrintingReach_1() As String
            Get
                Return ResourceManager.GetString("Warn_MaxCartonPrintingReach_1", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ระบบจะเรียงลำดับจากหมายเลขแรกไปจนครบจำนวนสูงสุด.
        '''</summary>
        Friend ReadOnly Property Warn_MaxCartonPrintingReach_2() As String
            Get
                Return ResourceManager.GetString("Warn_MaxCartonPrintingReach_2", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to McID ไม่รองรับในขั้นตอนนี้ กรุณาตรวจสอบ.
        '''</summary>
        Friend ReadOnly Property Warn_McIDScanNotSupport() As String
            Get
                Return ResourceManager.GetString("Warn_McIDScanNotSupport", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to MSS User นี้ไม่สามารถใช้งานเมนูนี้ได้.
        '''</summary>
        Friend ReadOnly Property Warn_MSSUserNoSkillRequired() As String
            Get
                Return ResourceManager.GetString("Warn_MSSUserNoSkillRequired", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ไม่สามารถสร้าง Pallet ใหม่ได้ เนื่องจาก Carton ID ทั้งหมดเสร็จสิ้นแล้ว.
        '''</summary>
        Friend ReadOnly Property Warn_NoCartonForNewPallet() As String
            Get
                Return ResourceManager.GetString("Warn_NoCartonForNewPallet", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ไม่มีข้อมูล Carton ID ที่สามารถ Print ได้ กรุณาตรวจสอบ.
        '''</summary>
        Friend ReadOnly Property Warn_NoCartonValidForPrint() As String
            Get
                Return ResourceManager.GetString("Warn_NoCartonValidForPrint", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ไม่พบข้อมูลที่ถูกเปลี่ยนแปลงสำหรับการบันทึก กรุณาตรวจสอบอีกครั้ง.
        '''</summary>
        Friend ReadOnly Property Warn_NoChangedForSave() As String
            Get
                Return ResourceManager.GetString("Warn_NoChangedForSave", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to กรุณาเลือกหมายเลข Invoice ที่ต้องการก่อนดำเนินการต่อ.
        '''</summary>
        Friend ReadOnly Property Warn_NoInvoiceSelected() As String
            Get
                Return ResourceManager.GetString("Warn_NoInvoiceSelected", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ไม่พบข้อมูล Pallet สำหรับดำเนินการ กรุณาตรวจสอบ.
        '''</summary>
        Friend ReadOnly Property Warn_NoPalletInputForCarton() As String
            Get
                Return ResourceManager.GetString("Warn_NoPalletInputForCarton", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to เกิดปัญหาขณะระบบกำลังลบไฟล์ กรุณาตรวจสอบหากไฟล์เดิมถูกเปิดค้างไว้.
        '''</summary>
        Friend ReadOnly Property Warn_OpenedFileChkForDelete() As String
            Get
                Return ResourceManager.GetString("Warn_OpenedFileChkForDelete", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ระบบยังไม่รองรับการ Delete Pallet ที่มีสถานะ Close กรุณาติดต่อ Valor#420(LPN1).
        '''</summary>
        Friend ReadOnly Property Warn_PalletCloseNotAllowDelete() As String
            Get
                Return ResourceManager.GetString("Warn_PalletCloseNotAllowDelete", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ระบบไม่อนุญาตการบันทึก กรุณาลบ Pallet ที่ไม่มี Carton ก่อนลองอีกครั้ง.
        '''</summary>
        Friend ReadOnly Property Warn_PalletNoCartonMustDeleted() As String
            Get
                Return ResourceManager.GetString("Warn_PalletNoCartonMustDeleted", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to กรุณาระบุจำนวน Carton ที่ต้องการสำหรับ Invoice.
        '''</summary>
        Friend ReadOnly Property Warn_PleaseInputBoxQuantity() As String
            Get
                Return ResourceManager.GetString("Warn_PleaseInputBoxQuantity", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to กรุณาเลือกหมายเลข Carton ID ที่ต้องการ Print ก่อนดำเนินการต่อ.
        '''</summary>
        Friend ReadOnly Property Warn_PleaseSelectBoxToPrint() As String
            Get
                Return ResourceManager.GetString("Warn_PleaseSelectBoxToPrint", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to เกิดข้อผิดพลาดในการ Print ดังรายการนี้ กรุณาติดต่อ Valor#420(LPN1).
        '''</summary>
        Friend ReadOnly Property Warn_PrintingErrorOccurs() As String
            Get
                Return ResourceManager.GetString("Warn_PrintingErrorOccurs", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ไม่สามารถ Print ได้ กรุณาสร้าง Pallet ให้ครบถ้วนทุก Carton ก่อนดำเนินการต่อ.
        '''</summary>
        Friend ReadOnly Property Warn_PrintNotAllowWhenCartonLeft() As String
            Get
                Return ResourceManager.GetString("Warn_PrintNotAllowWhenCartonLeft", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to . . . ระบบกำลังประมวลผล และบันทึกข้อมูล . . ..
        '''</summary>
        Friend ReadOnly Property Warn_ProgramIsSaving() As String
            Get
                Return ResourceManager.GetString("Warn_ProgramIsSaving", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ข้อมูลการทำงานก่อนหน้าจะถูกยกเลิกทั้งหมด ยืนยันการ Re-load หรือไม่ ?.
        '''</summary>
        Friend ReadOnly Property Warn_ReloadAfterInvScan() As String
            Get
                Return ResourceManager.GetString("Warn_ReloadAfterInvScan", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ยืนยันการยกเลิกสถานะ Close ของ Pallet นี้หรือไม่ ?
        '''
        '''หากมีข้อมูลการตรวจสอบ Pallet ของ QA จะถูกยกเลิกทั้งหมดเช่นกัน.
        '''</summary>
        Friend ReadOnly Property Warn_ReOpenPalletConfirm() As String
            Get
                Return ResourceManager.GetString("Warn_ReOpenPalletConfirm", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ไม่สามารถ Reset ข้อมูลได้ กรุณาตรวจสอบ หรือติดต่อ Valor#420(LPN1).
        '''</summary>
        Friend ReadOnly Property Warn_ResetCartonRejected() As String
            Get
                Return ResourceManager.GetString("Warn_ResetCartonRejected", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ข้อมูลที่ไม่ถูก Save จะถูกยกเลิกทั้งหมด ยืนยันการยกเลิกข้อมูลชุดนี้หรือไม่ ?.
        '''</summary>
        Friend ReadOnly Property Warn_UnsaveInfoWillCancel() As String
            Get
                Return ResourceManager.GetString("Warn_UnsaveInfoWillCancel", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to กรุณาสแกน Invoice สำหรับ Outer ก่อนดำเนินการต่อ.
        '''</summary>
        Friend ReadOnly Property Warn_WaitScanInvForOuter() As String
            Get
                Return ResourceManager.GetString("Warn_WaitScanInvForOuter", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to กรุณาสแกนหมายเลข Invoice ถัดไปที่อยู่ในกลุ่ม.
        '''</summary>
        Friend ReadOnly Property Warn_WaitScanNextInvInGroup() As String
            Get
                Return ResourceManager.GetString("Warn_WaitScanNextInvInGroup", resourceCulture)
            End Get
        End Property
    End Module
End Namespace