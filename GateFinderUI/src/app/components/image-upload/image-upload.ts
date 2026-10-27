import { Component, OnDestroy } from '@angular/core';
import { OcrService } from '../../services/orc.service';
import { BaseResponse } from '../../dtos/baseResponse.dto';
import { ExtractDataResponseDto } from '../../dtos/ocr.dto';
import { PackageDataService } from '../../services/packageData.service';
import { PackageDataDto } from '../../dtos/packageData.dto';

@Component({
  imports: [],
  selector: 'app-image-upload',
  styleUrl: './image-upload.css',
  templateUrl: './image-upload.html',
})
export class ImageUpload implements OnDestroy {
  selectedFiles: File[] = [];
  previewImages: { name: string; url: string; }[] = [];

  constructor(private ocrService: OcrService, private packageDataService: PackageDataService) {}

  ngOnDestroy(): void {
    for (const image of this.previewImages) {
      URL.revokeObjectURL(image.url);
    }
  }

  onFilesSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    const files = Array.from(input.files ?? []);

    const validFiles = files.filter(file =>
      file.type.startsWith('image/')
    );

    this.selectedFiles.push(...validFiles);

    for (const file of validFiles) {
      this.previewImages.push({
        name: file.name,
        url: URL.createObjectURL(file)
      });
    }

    input.value = '';
  }

  removeImage(image: { name: string; url: string }): void {
    const index = this.previewImages.indexOf(image);

    if (index === -1) return;

    URL.revokeObjectURL(image.url);
    this.previewImages.splice(index, 1);
    this.selectedFiles.splice(index, 1);
  }

  uploadImages(): void {
    const formData = new FormData();

    for (const file of this.selectedFiles) {
      formData.append('images', file, file.name);
    }

    this.ocrService.extract(formData).subscribe((response) => {
      if (response.isSuccess && response.data != null) {
        this.packageDataService.clearPackageData();

        for (let product of response.data) {
          let productId: string | null = null;
          let productAddress: string | null = null;

          for (let detail of product) {
            if (detail.title === 'รหัสสินค้า') {
              productId = detail.value;
              continue;
            }

            if (detail.title === 'ที่อยู่จัดส่ง') {
              productAddress = detail.value;
              continue;
            }

            if (productId != null && productAddress != null) break;
          }

          if (productId != null && productAddress != null) this.packageDataService.addPackageData(productId, productAddress);
        }
      }
    })
  }
}
