import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ThemeSharedModule, ConfirmationService, Confirmation } from '@abp/ng.theme.shared'; // ConfirmationService eklendi
import { RoadmapService } from '../proxy/roadmaps/roadmap.service';

@Component({
  selector: 'app-roadmap-detail',
  standalone: true,
  imports: [CommonModule, RouterModule, ThemeSharedModule, ReactiveFormsModule],
  templateUrl: './roadmap-detail.html',
})
export class RoadmapDetailComponent implements OnInit {
  roadmap: any = {};
  steps: any[] = [];
  roadmapId: string;
  isModalOpen = false;
  form: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private roadmapService: RoadmapService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService // Constructor'a eklendi
  ) {}

  ngOnInit() {
    this.roadmapId = this.route.snapshot.paramMap.get('id');
    this.buildForm();
    if (this.roadmapId) {
      this.fetchData();
    }
  }

  buildForm() {
    this.form = this.fb.group({
      roadmapId: [this.roadmapId],
      title: ['', Validators.required],
      description: ['', Validators.required],
      order: [0, Validators.required],
    });
  }

  openModal() {
    this.form.reset({ 
      roadmapId: this.roadmapId, 
      order: this.steps.length + 1 
    });
    this.isModalOpen = true;
  }

  fetchData() {
    this.roadmapService.get(this.roadmapId).subscribe((result) => {
      this.roadmap = result;
    });
    
    this.roadmapService.getStepsByRoadmapId(this.roadmapId).subscribe((result) => {
      this.steps = result;
    });
  }

  saveStep() {
    if (this.form.invalid) return;

    const payload = { ...this.form.value, roadmapId: this.roadmapId };

    this.roadmapService.createStep(payload).subscribe({
      next: () => {
        this.isModalOpen = false;
        this.fetchData();
        this.form.reset({ roadmapId: this.roadmapId, order: this.steps.length + 1 });
      },
      error: (err) => {
        console.error("Kayıt sırasında bir hata oluştu:", err);
      }
    });
  }

  // --- YENİ: ADIM SİLME METODU ---
  deleteStep(id: string) {
    this.confirmation.warn(
      'Bu eğitim adımını silmek istediğinize emin misiniz?',
      'Adım Silinecek'
    ).subscribe((status: Confirmation.Status) => {
      // ABP'de 1 onayı temsil eder
      if ((status as any) === 1 || status === Confirmation.Status.confirm) {
        this.roadmapService.deleteStep(id).subscribe({
          next: () => {
            this.fetchData(); // Listeyi güncelle
          },
          error: (err) => {
            console.error("Adım silinirken bir hata oluştu:", err);
          }
        });
      }
    });
  }
}