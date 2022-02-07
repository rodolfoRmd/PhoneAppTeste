import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { PersonPhoneVO } from '../person-phone-vo';
import { PersonPhoneService } from '../person-phone.service';
import { PhoneTypeVO } from '../phone-type-vo';
import { PhoneTypeService } from '../phone-type.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-person-phone',
  templateUrl: './person-phone.component.html',
  styleUrls: ['./person-phone.component.css']
})
export class PersonPhoneComponent implements OnInit {

  public allPersonPhones: PersonPhoneVO[];  
  public allTypes: PhoneTypeVO[];  
  public personPhoneSelecionado: PersonPhoneVO;
  public personPhoneForm: FormGroup;
  public verboHTTP = 'post';
  public personPhoneVo: PersonPhoneVO;


  constructor(private personPhoneService :PersonPhoneService, 
    private phoneTypeService : PhoneTypeService,
    private fb:FormBuilder,
    private toastr: ToastrService
    ) { 

    this.criarForm();
  }
  ngOnInit(): void {
    this.loadAllPersonPhones(); 
    this.loadAllTypes();
  }

  criarForm(){
    this.personPhoneForm = this.fb.group({
    
      id: [0],
      phoneNumber: ['', Validators.required],
      idPhoneNumberType: [0, Validators.required]
    });
  }

  loadAllPersonPhones() {  
     this.personPhoneService.getAll().subscribe(
      (personPhones: PersonPhoneVO[]) =>{
          this.allPersonPhones = personPhones;
      },
      (erro: any)=>{
        console.error(erro);
      }

    );  
  } 

  loadAllTypes(){
    this.phoneTypeService.getAll().subscribe(
      (phoneTypes: PhoneTypeVO[]) =>{
          this.allTypes = phoneTypes;
      },
      (erro: any)=>{
        console.error(erro);
      }

    );  
  }
 getDescType(id:number):string{

  return this.allTypes.find(x=>x.id===id).name;
 }
  
  selecionarPerson(personPhone: PersonPhoneVO) {
    this.personPhoneSelecionado = personPhone;
    this.personPhoneForm.patchValue(personPhone);
    this.verboHTTP = 'put';
  }
  voltar() {
    this.personPhoneSelecionado = null;
    this.personPhoneForm.reset();
  }


  salvarPhoneNumber() {
      if (this.verboHTTP === 'post') {
        this.personPhoneVo = {...this.personPhoneForm.value};
      } else {
        this.personPhoneVo = {id: this.personPhoneSelecionado.id, ...this.personPhoneForm.value};
      }

      this.personPhoneService[this.verboHTTP](this.personPhoneVo)
        // .pipe(takeUntil(this.unsubscriber))
        .subscribe(
          () => {
            this.toastr.success('Save Executado com Sucesso!');
          
            this.loadAllPersonPhones(); 
            this.personPhoneSelecionado = null;
           
          }, (error: any) => {
             this.toastr.error('Falha ao executar a ação');
            console.error(error);
          }
        );

    }

    deletePersonPhone(id:number){
      this.personPhoneService.del(id)
     
      .subscribe(
        () => {
         
          this.toastr.success("Delete Executado com Sucesso");
          this.loadAllPersonPhones(); 
          this.personPhoneSelecionado = null;
         
        }, (error: any) => {
          this.toastr.error('Falha ao executar a ação');
          console.error(error);
        }
      );
    }

    novo(){

      this.personPhoneSelecionado = {id:-1, phoneNumber:'', idPhoneNumberType:0};
      this.personPhoneForm.patchValue(this.personPhoneSelecionado);
      this.verboHTTP = 'post';
      
    }
  

}

