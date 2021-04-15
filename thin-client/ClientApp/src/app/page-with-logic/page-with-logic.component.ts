import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-page-with-logic',
  templateUrl: './page-with-logic.component.html',
})
export class PageWithLogicComponent { 
    public returnObject: ReturnObject;
    public timeToLoad: number = 0;
    private startTime: number;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.startTime = Date.now();
    http.get<ReturnObject>(baseUrl + 'data').subscribe(result => {
      this.returnObject = result;
    }, error => console.error(error));
  }

  setTime() {
      this.timeToLoad = Date.now() - this.startTime;
  }

  shouldBeRed(value: string, index: number): boolean {
      var isRed = false;
      for (let i = 0; i < value.length; i++) {
          if (value.charAt(i) === 'r') {
              for (let j = i + 1; j < value.length; j++) {
                  if (value.charAt(j) === 'e') {
                      for (let k = j + 1; k < value.length; k++) {
                          if (value.charAt(k) === 'd') {
                            isRed = true;
                          }
                      }
                  }
              }
          }
      }
      if (index === this.returnObject.data.length - 1) {
          this.setTime();
      }
      return isRed;
  }
}

interface ReturnObject {
    data: string[];
  }
