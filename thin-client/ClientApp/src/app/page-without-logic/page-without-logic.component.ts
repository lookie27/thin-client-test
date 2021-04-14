import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-page-without-logic',
  templateUrl: './page-without-logic.component.html',
})
export class PageWithoutLogicComponent {
public returnObject: ReturnObject;
public tuples$: Observable<Tuple[]>;
public timeToLoad: number;

constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  let currentTime = Date.now();
    this.tuples$ = http.get<ReturnObject>(baseUrl + 'data').pipe(
      map(returnObject => returnObject.data),
      map(strings => strings.map(value => {
        let tuple = new Tuple();
        tuple.value = value;
        this.shouldBeRed(value).subscribe(isRed => {
          tuple.isRed = isRed;
        });

        return tuple;
      }))
    );

    this.tuples$.subscribe(() => {
      this.timeToLoad = Date.now() - currentTime;
    })
  }

  shouldBeRed(value: string): Observable<boolean> {
    return this.http.get<boolean>(this.baseUrl + 'data/should-be-red/' + value);
  }
}

interface ReturnObject {
  data: string[];
}

class Tuple {
  value: string;
  isRed: boolean;
}
