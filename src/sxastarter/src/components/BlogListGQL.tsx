import React from 'react';
import { LinkField, Field, ImageField } from '@sitecore-jss/sitecore-jss-nextjs';
import { Default } from './Promo';
import {
    ImageField,
    Field,
    LinkField,
  } from '@sitecore-jss/sitecore-jss-nextjs';
  
  interface Fields {
    PromoIcon: ImageField;
    PromoText: Field<string>;
    PromoLink: LinkField;
    PromoText2: Field<string>;
    PromoIcon2: ImageField;
    PromoText3: Field<string>;
  }
  interface BlogInterface {
    id: string;
    url: string;
    name: string;
    displayName: string;
    fields: Fields;
  }
  
  export type BlogListProps = {
    uid: string;
    componentName: string;
    dataSource: string;
    params: {
      DynamicPlaceholderId: string;
    };
    fields: {
      Blog: BlogInterface[];
    };
  };

  const PromoList = (props: BlogListProps): JSX.Element => {
    // Fail out if fields aren't present
    if (props.fields === null || props.fields === undefined) return <></>;
  
    return (
      <div className="flex flex-wrap container mx-auto">
        {props?.fields?.Blogs?.map((val, i) => {
          return <>
          <div className='flex flex-wrap col-md-6'>
          <Default params={props?.params} fields={val?.fields} key={i} />
          </div>
          </>;
        })}
      </div>
    );
  };
  
  export default PromoList;
